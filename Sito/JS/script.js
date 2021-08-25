var app = new Vue({
    el: '#vue-container',
    data: {
        tipo: 0,
        vis1: true,
        vis2: false,
        altezza: 400,

    },
    mounted(){
        console.log("Vue funziona");
    },
    methods: {
        selezionaTipo(i){
            this.altezza=this.$refs.form.clientHeight;
            console.log(this.altezza);
            this.tipo=i;

            document.getElementsByClassName("form")[0].style.height = this.altezza.toString()+"px";
            this.vis1=false;

            console.log(this.tipo);
            setTimeout(function() {app.vis2=true }, 700);
        },
        
    }
});