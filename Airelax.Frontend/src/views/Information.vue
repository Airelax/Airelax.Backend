<template>
    <div v-if="get" class="checkbox row">
        <div class="col-md-3 brief">
            <h1 v-if="width<768">收件匣</h1>
            <h1 v-else>訊息</h1>
            <div class="briefmessage">
                <Brief :messages="messages"></Brief>
            </div>
        </div>
        <div v-if="width>768" class="col-md-9">
            <MainMessage></MainMessage>
        </div>
    </div>
</template>

<script>
import axios from "axios";
import Brief from '../components/Information/BriefMessage';
import MainMessage from '../components/Information/MainMessage';
import settingJson from "../components/Settings/setting";

export default {
    created(){
        axios
        .get(`/api/messages/${this.$route.params.memberId}`, {
          headers: {
            "Access-Control-Allow-Origin": "*",
          },
        })
        .then((res) => {
            this.messages = res.data;
            this.messages.forEach(x=>{
                this.getLandlordCover(x);
                this.getPortrait(x);
                this.getPrice(x);
                this.getPicture(x);
            });
            this.$store.state.signalCommunications = [];
            this.get = true;
            console.log(this.messages);
        });
    },
    data(){
        return{
            get: false,
            messages: [],
            setting: settingJson
        }
    },
    components:{Brief, MainMessage},
    computed:{
        width(){
            return this.$store.state.fullWidth;
        }
    },
    methods:{
        getRandomNumber(min,max){
            return Math.floor(Math.random() * (max-min+1))+min;
        },
        getRandomList(min,max,num){
            var list = [];
            while (list.length != num) {
                var randomNumber = Math.floor(Math.random() * (max-min+1))+min;
                if (!list.some((x) => {return x == randomNumber;})
                ) { list.push(randomNumber);}
            }
            return list;
        },
        //Todo-先給隨機LandlordCover資料
        getLandlordCover(messages){
            if(messages.landlord.cover !== null) return;
            let num = this.getRandomList(0,this.setting.portraits.length-1,1)[0];
            messages.landlord.cover = this.setting.portraits[num];
        },
        //Todo-先給隨機Portrait資料
        getPortrait(messages){
            if(messages.portrait !== null) return;
            let num = this.getRandomList(0,this.setting.portraits.length-1,1)[0];
            messages.portrait = this.setting.portraits[num];
        },
        //Todo-先給隨機Price資料
        getPrice(messages){
            if(messages.paymentDetail.serviceFee !== 0) return;
            Object.keys(messages.paymentDetail).forEach(x=>{
                messages.paymentDetail[x] = Math.round(messages.origin*0.1+this.getRandomNumber(1,messages.origin/5));
            });
        },
        //Todo-先給隨機Picture資料
        getPicture(messages) {
            if(messages.pictures.length !== 0) return;
            let num = this.getRandomList(0,this.setting.pictures.length-1,1)[0];
            messages.pictures.push(this.setting.pictures[num]);
        },
    }
}
</script>

<style lang="scss" scoped>
@import "../assets/css/reset.css";
.checkbox{
    padding: 1rem;
    h1{
        text-align: start;
        font-size: 1.7rem;
        font-weight: 700;
        margin: 1rem 0;
        padding-bottom: 1rem;
        border-bottom: 1px solid #ff385c;
    }
    .briefmessage{
        overflow-y: scroll;
        height: 78vh;
    }
}
@media screen and (min-width: 768px){
    .checkbox{
        margin-top: 5.5rem;
        padding:0;
        height: 87.8vh;
        .brief{
            border-right: 1px solid rgb(209, 206, 206);
            h1{
                font-size: 1.2rem;
                margin-top: .5rem;
                border-bottom: 1px solid rgb(209, 206, 206);
                padding: 1.05rem .8rem;
            }
            .briefmessage{
                height: 76vh;
            }
        }
    }
}
</style>