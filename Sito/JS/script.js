var app = new Vue({
    el: '#vue-container',
    data: {
        tipo: 0,
        linea: 0,
        data: "",
        vis1: true,
        vis2: false,
        vis3: false,
        vis4: false,
        altezza: 400,

    },
    mounted(){
        console.log("Vue funziona");
    },
    methods: {
        selezionaTipo(i){
            this.altezza=this.$refs.form.clientHeight-40;
            this.tipo=i;
            console.log(this.tipo);

            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            this.vis1=false;

            setTimeout(function() {app.vis2=true }, 700);
            
            
        },
        selezionaClasse(i)
        {
            this.altezza=this.$refs.form.clientHeight;
            this.linea=i;
            console.log(this.linea);

            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            this.vis2=false;
            if(this.tipo!=1)
                setTimeout(function() {app.vis3=true }, 700);
            else
            {
                setTimeout(function() {app.vis4=true }, 700);
                setTimeout(function() {app.creaBiglietto()}, 1500);
            } 
            
        },
        selezionaData()
        {
            this.data=document.getElementById("datepicker").value;
            console.log(this.data);
            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            this.vis3=false;
            setTimeout(function() {app.creaBiglietto()}, 1500);
            setTimeout(function() {app.vis4=true }, 700);
        },
        creaBiglietto()
        {
            var id=creaId(12);
            console.log(id);
            var qrcode=this.generaQr(id);
            setTimeout(function() {app.generaPdf()}, 1000);
        },
        generaQr(id)
        {
            var qrcode = new QRCode(document.getElementById("qrcode"), {
                text: id,
                width: 300,
                height: 300,
                colorDark : "#000000",
                colorLight : "#ffffff",
                correctLevel : QRCode.CorrectLevel.H
            });
            return qrcode;
        },
        generaPdf()
        {
            var pdf = new jsPDF({
                orientation: "landscape",
                unit: "mm",
                format: [168, 60]
            });
            var base64Image = document.getElementById("qrcode").getElementsByTagName("img")[0].src;
            var titolo="";
            if(this.tipo==1)
                titolo="Biglietto singolo C"+this.linea.toString();
            else if(this.tipo==2)
                titolo="Abbonamento settimanale C"+this.linea.toString();
            else if(this.tipo==3)
                titolo="Abbonamento mensile C"+this.linea.toString();

            var data="";
            if(this.tipo!=1)
                data="Inizio abbonamento: "+this.data;
            //immagine
            pdf.addImage(base64Image, 'png', 5, 5, 50, 50);
            //titolo
            pdf.setFontSize(20);
            pdf.setFontType("bold");
            pdf.text(titolo, 60, 15);
            //data
            pdf.setFontSize(16);
            pdf.setFontType("normal");
            pdf.text(data, 60, 28);
            //istruzioni
            pdf.setFontSize(13);
            pdf.setFontType("bold");
            pdf.text("Obliterare alla salita sul BUS!", 60, 38);
            //marketing
            pdf.setFontSize(10);
            pdf.text("PrenoBUS v1.0", 140, 56);
            
            pdf.save("prova.pdf");


        }
    }
});
function modificaSize()
{
    document.getElementsByClassName("form")[0].style.height = "auto";
}
function creaId(length) 
{
    var result           = '';
    var characters       = 'abcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
   }
   return result;
}
window.addEventListener("resize", modificaSize);