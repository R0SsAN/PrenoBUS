var app = new Vue({
    el: '#vue-container',
    data: {
        tipo: 0,
        linea: 0,
        data: "",
        datafine: "",
        id: "",
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
            //imposto altezza form
            this.altezza=this.$refs.form.clientHeight-40;
            //setto il tipo di biglietto e passo al check successivo
            this.tipo=i;
            console.log(this.tipo);
            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            this.vis1=false;

            setTimeout(function() {app.vis2=true }, 700);
            
            
        },
        selezionaClasse(i)
        {
            this.altezza=this.$refs.form.clientHeight-40;
            //setto la lina
            this.linea=i;
            console.log(this.linea);

            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            //if biglietto = singolo -> credo direttamente il biglietto
            //if biglietto = abbonamento -> apro il form della scelta data
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
            this.altezza=this.$refs.form.clientHeight-40;
            //setto la data del biglietto
            this.data=document.getElementById("datepicker").value;
            console.log(this.data);

            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            
            this.vis3=false;
            setTimeout(function() {app.creaBiglietto()}, 1500);
            setTimeout(function() {app.vis4=true }, 700);
        },
        creaBiglietto()
        {
            this.altezza=this.$refs.form.clientHeight-40;
            
            this.creaFine();
            //genero l'id univoco del biglietto
            this.id=creaId(12);
            console.log(this.id);
            document.getElementById("intestazione").innerHTML="Riepilogo Biglietto:";
            //genero il riepilogo finale del biglietto, poi creo il codice qr e infine 
            // aggiorno il database sql online
            this.generaRiepilogo();
            this.generaQr();
            setTimeout(function() {app.aggiornaSql()}, 1000);
        },
        generaQr()
        {
            //genero il qr relativo all'id del biglietto e lo visualizzo
            var qrcode = new QRCode(document.getElementById("qrcode"), {
                text: this.id,
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
            //genero il biglietto pdf e lo faccio scaricare
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


        },
        aggiornaSql()
        {
            //collego il sito ad un api che salva il biglietto nel database sql
            var httpr=new XMLHttpRequest();
            httpr.open("POST","http://prenobus.epizy.com/api.php",true);
            httpr.setRequestHeader("Content-type","application/x-www-form-urlencoded");
            httpr.onreadystatechange=function(){
                if(httpr.readyState==4 && httpr.status==200){
                    console.log(httpr.responseText);
                }
            }
            httpr.send("linea="+this.linea.toString()+"&codiceqr="+this.id+"&inizio="+this.data+"&fine="+this.datafine);
        },
        creaFine()
        {
            //genero la data di fine dell'abbonamento
            var data=new Date(this.data);
            if(this.tipo!=1)
            {
                if(this.tipo==2)
                data.setDate(data.getDate()+7);
                else if(this.tipo==3)
                    data.setDate(data.getDate()+30);
                this.datafine=data;
                this.datafine = data.toISOString().slice(0,10);
            }
            else
            {
                this.data="-";
                this.datafine="-";
            }
            console.log(this.datafine);
        },
        generaRiepilogo()
        {
            //visualizzo le informazioni finali del biglietto/abbonamento
            if(this.tipo==1)
                document.getElementById("rTit").innerHTML="Biglietto singolo linea C"+this.linea.toString();
            else
            {
                if(this.tipo==2)
                    document.getElementById("rTit").innerHTML="Abbonamento settimanale linea C"+this.linea.toString();
                else if(this.tipo==3)
                    document.getElementById("rTit").innerHTML="Abbonamento mensile linea C"+this.linea.toString();
                document.getElementById("rIn").innerHTML="Data inizio: "+this.data;
                document.getElementById("rFin").innerHTML="Data fine: "+this.datafine;

            }
        },
        ritornaHome()
        {
            //ritorno alla schermata iniziale del sito
            this.altezza=this.$refs.form.clientHeight-40;
            this.vis4=false;
            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            setTimeout(function() {app.vis1=true }, 700);
        }
        
    }
});
function modificaSize()
{
    document.getElementsByClassName("form")[0].style.height = "auto";
}
function creaId(length) 
{
    //genera un id di n caratteri random
    var result           = '';
    var characters       = 'abcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
   }
   return result;
}
window.addEventListener("resize", modificaSize);