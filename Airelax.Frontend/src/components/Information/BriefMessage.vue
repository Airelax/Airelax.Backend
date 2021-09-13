<template>
    <button v-if="width>768" class="btn btn-danger d-none show-message" @click="removeJoin">顯示聊天清單</button>
    <div v-for="item in messages" :key="item.id">
        <div class="brief hide-message" @click="sendData(item)">
            <a v-if="width<768" class="messageBox" data-bs-toggle="offcanvas" href="#offcanvasRight" role="button" aria-controls="offcanvasRight">
                <div class="row d-flex align-items-center py-2">
                    <div class="col-2">
                        <div class="img"><img :src="getReceiver(item).portrait"></div>
                    </div>
                    <div class="col-8 text">
                        <div class="name">[{{getReceiver(item).nickname}}] {{getReceiver(item).name}} {{count}}</div>
                        <div class="message" v-if="getMessage(item).content.length<=12">{{getMessage(item).content}}</div>
                        <div class="message" v-else>{{getMessage(item).content.slice(0,12)}}...</div>
                        <div class="bookingDate">{{item.tourDetail.startDate.split('T')[0]}} 至 {{item.tourDetail.endDate.split('T')[0]}}</div>
                    </div>
                    <div class="col-2 info d-flex flex-column align-items-center">
                        <div class="lastestDate">{{getMessage(item).time.split('T')[0].split('-')[1]}}/{{getMessage(item).time.split('T')[0].split('-')[2]}}</div>
                        <div class="uncheck" v-if="item.memberId == item.landlord.id && item.memberOneStatus != 0">{{item.memberOneStatus}}</div>
                        <div class="uncheck" v-else-if="item.memberId != item.landlord.id && item.memberTwoStatus != 0">{{item.memberTwoStatus}}</div>
                    </div>
                </div>
            </a>
            <a v-else class="messageBox" >
                <div class="row d-flex align-items-center py-2">
                    <div class="col-2">
                        <div class="img"><img :src="getReceiver(item).portrait"></div>
                    </div>
                    <div class="col-8 text">
                        <div class="name">[{{getReceiver(item).nickname}}] {{getReceiver(item).name}} {{count}}</div>
                        <div class="message" v-if="getMessage(item).content.length<=12">{{getMessage(item).content}}</div>
                        <div class="message" v-else>{{getMessage(item).content.slice(0,12)}}...</div>
                        <div class="bookingDate">{{item.tourDetail.startDate.split('T')[0]}} 至 {{item.tourDetail.endDate.split('T')[0]}}</div>
                    </div>
                    <div class="col-2 info d-flex flex-column align-items-center">
                        <div class="lastestDate">{{getMessage(item).time.split('T')[0].split('-')[1]}}/{{getMessage(item).time.split('T')[0].split('-')[2]}}</div>
                        <div class="uncheck" v-if="item.memberId == item.landlord.id && item.memberOneStatus != 0">{{item.memberOneStatus}}</div>
                        <div class="uncheck" v-else-if="item.memberId != item.landlord.id && item.memberTwoStatus != 0">{{item.memberTwoStatus}}</div>
                    </div>
                </div>
            </a>
        </div>
    </div>

    <div v-if="width<768" class="offcanvas offcanvas-end" data-bs-scroll="true" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
        <div class="offcanvas-header d-flex flex-column align-items-start p-0">
            <div class="d-flex justify-content-start align-items-center py-3">
                <button type="button" class="btn d-flex align-items-center" data-bs-dismiss="offcanvas" aria-label="Close" @click="removeJoin">
                    <img src="../../assets/image/Room/icon/back.svg"/>
                </button>
                <div class="title">
                    <h2 id="offcanvasRightLabel" v-if="Object.keys(mes).length != 0">[{{getReceiver(mes).nickname}}] {{getReceiver(mes).name}}</h2>
                    <div>回覆時間：1 小時</div>
                </div>
            </div>
            <a href="#" class="row mix d-flex w-100  p-3 align-items-center" @click.prevent="goRoom">
                <div class="col-2">
                    <div class="img" v-if="Object.keys(mes).length != 0"><img :src="mes.pictures[0]"></div>
                </div>
                <div class="col-10 text-start">
                    <h3 v-if="Object.keys(mes).length != 0">{{mes.tourDetail.title.slice(0,20)}}...</h3>
                    <div class="bookingDate" v-if="Object.keys(mes).length != 0">{{mes.tourDetail.startDate.split('T')[0]}} 至 {{mes.tourDetail.endDate.split('T')[0]}}</div>
                </div>
            </a>
        </div>
        <div class="offcanvas-body">
            <Talk :message="mes"></Talk>
            <Signal :message="mes"></Signal>
        </div>
        <div class="offcanvas-footer">
            <div class="input"><input type="text" v-model="msg" placeholder="輸入訊息" @keydown.enter="sengMsg"></div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
import Talk from '../Information/Talk';
import Signal from '../Information/SignalMessage';
import * as signalR from '@microsoft/signalr';
import moment from 'moment';

let hubUrl = "https://localhost:5001/chatHub";
const connection = new signalR.HubConnectionBuilder().withAutomaticReconnect().withUrl(hubUrl).build();
connection.start().catch(err=>console.log(err));

export default {
    components:{Talk, Signal},
    props:['allMsg'],
    inject: ["reload"],
    data(){
        return{
            mes:{},
            receiver: "",
            msg: "",
            count: 0,
            messages: this.allMsg
        }
    },
    watch:{
        count(val){
            if(val==1){
                console.log("只有一個人")
            }
            else if(val==2){
                console.log("大家都在了")
            }
        }
    },
    computed:{
        width(){
            return this.$store.state.fullWidth;
        }
    },
    mounted(){
        var vm = this;
        vm.$store.state.connection = connection;
        vm.mix();
    },
    updated(){
        this.scrollToBottom();
    },
    methods:{
        mix(){
            var vm = this;

            vm.$store.state.readedCount = 0;
            vm.$store.state.readed = false;

            vm.messages.forEach(x=>{
                connection.invoke("AddAllGroup", x.connectString);
            });

            axios.get(`/api/messages/${vm.$route.params.memberId}`, {
                headers: {"Access-Control-Allow-Origin": "*",}})
                .then((res) => {
                    vm.messages = res.data;
            });

            connection.on("ReceiveMessage",function(objString,message){
                console.log(message)
                var objItem = JSON.parse(objString);

                let com = {
                    senderId: objItem.memberId,
                    receiverId: objItem.gusetId,
                    content: message,
                    time: moment(new Date()).format('YYYY-MM-DD[T]HH:mm:ss')
                }
                
                let ontime = {
                    MemberId: objItem.memberId,
                    OtherId: objItem.gusetId
                }
                
                for(let i = 0; i < vm.messages.length; i++){
                    if(vm.messages[i].gusetId == objItem.memberId){
                        console.log("收到訊息囉");
                        if(Object.keys(vm.mes).length != 0 ){
                            vm.$store.state.signalCommunications.push(com);
                        }
                        connection.invoke("GetCount", vm.mes.connectString).then(x=>{
                            vm.count = x
                            if(vm.count==2){
                                vm.mes.memberTwoStatus = 0;
                                vm.$store.state.readed = true;
                            }
                            else{
                                setTimeout(()=>{
                                    axios.get(`/api/messages/${vm.$route.params.memberId}`, {
                                    headers: {"Access-Control-Allow-Origin": "*",}})
                                    .then((res) => {
                                        vm.messages = res.data;
                                    });
                                },1000);
                            }
                        })

                        vm.scrollToBottom();
                        break;
                    }
                    else if (vm.messages[i].memberId == objItem.memberId){
                        vm.$store.state.signalCommunications.push(com);
                        axios.put(`/api/messages/${vm.$route.params.memberId}/content`, com,{
                            headers: {
                            "Access-Control-Allow-Origin": "*",
                        }}).then((res)=>{
                            console.log(res.data)
                            connection.invoke("GetCount", vm.mes.connectString).then(x=>{
                                vm.count = x
                                if(vm.count==2){
                                    axios.put(`/api/messages/${vm.$route.params.memberId}/status`, ontime,{
                                    headers: {
                                        "Access-Control-Allow-Origin": "*",
                                    }}).then(function (res) {
                                            console.log(res.data)
                                            axios.get(`/api/messages/${vm.$route.params.memberId}`, {
                                                headers: {"Access-Control-Allow-Origin": "*",},
                                                }).then((res) => {
                                                    vm.messages = res.data;
                                            });
                                    })
                                    vm.mes.memberTwoStatus = 0;
                                    vm.$store.state.readedCount += 1;
                                    vm.$store.state.readed = true;
                                }
                                else {
                                    axios.put(`/api/messages/${vm.$route.params.memberId}/ontime`, ontime,{
                                    headers: {
                                        "Access-Control-Allow-Origin": "*",
                                    }}).then(function (res) {
                                            console.log(res.data)
                                            axios.get(`/api/messages/${vm.$route.params.memberId}`, {
                                                headers: {"Access-Control-Allow-Origin": "*",},
                                                }).then((res) => {
                                                    vm.messages = res.data;
                                            });
                                    })
                                    vm.$store.state.readed = false;
                                }
                            })
                        });
                        
                        vm.scrollToBottom();
                        break;
                    }
                }
            })
        },
        useAxios(com){
            axios.put(`/api/messages/${this.$route.params.memberId}/content`, com,{
            headers: {
                "Access-Control-Allow-Origin": "*",
            }}).then(function (res) {
                    console.log(res.data)
                }).catch(err=>{console.log(err)})
        },
        updateStatus(ontime){
            axios.put(`/api/messages/${this.$route.params.memberId}/status`, ontime,{
            headers: {
                "Access-Control-Allow-Origin": "*",
            }}).then(function (res) {
                    console.log(res.data)
            }).catch(err=>{console.log(err)})
        },
        updateOntime(ontime){
            axios.put(`/api/messages/${this.$route.params.memberId}/ontime`, ontime,{
            headers: {
                "Access-Control-Allow-Origin": "*",
            }}).then(function (res) {
                    console.log(res.data)
            }).catch(err=>{console.log(err)})
        },
        sengMsg(){
            var vm = this;
            connection.invoke("SendMessageToGroup",vm.mes.connectString, JSON.stringify(vm.mes), vm.msg )
            vm.msg="";
        },
        removeJoin(){
            var vm = this;
            if (vm.width>768){
                document.querySelectorAll('.hide-message').forEach(x=>{x.classList.remove('d-none')});
                document.querySelector('.show-message').classList.add('d-none');
                vm.$store.state.message = {};
            }
            connection.invoke("RemoveGroup", vm.mes.connectString).then(()=>{
                vm.$store.state.signalCommunications = [];
                vm.$store.state.readedCount = 0;
                vm.$store.state.readed = false;
                vm.count = 0;
                vm.messages.forEach(x=>{
                    connection.invoke("AddAllGroup", x.connectString);
                });
                axios.get(`/api/messages/${vm.$route.params.memberId}`, {
                    headers: {"Access-Control-Allow-Origin": "*",}})
                    .then((res) => {
                        vm.messages = res.data;
                });
            })
        },
        sendData(item){
            var vm = this;
            
            vm.mes = item;
            vm.$store.state.message = item;

            vm.messages.forEach(x=>{
                connection.invoke("RemoveAllGroup", x.connectString);
            })

            vm.$nextTick(()=>{
                vm.$store.state.signalCommunications = [];
                connection.invoke("AddGroup", item.connectString).then(()=>{
                    connection.invoke("GetCount", vm.mes.connectString).then(x=>{vm.count = x})
                })
            });

            //已讀
            let com = {
                MemberId: item.memberId,
                OtherId: item.gusetId
            }
            if(item.memberId == item.landlord.id){
                if(item.memberOneStatus != 0) vm.updateStatus(com);
            }
            else{
                if(item.memberTwoStatus != 0) vm.updateStatus(com);
            }

            if(vm.width > 768){
                document.querySelectorAll('.hide-message').forEach(x=>{x.classList.add('d-none')})
                document.querySelector('.show-message').classList.remove('d-none');
            }
        },
        getReceiver(item){
            if(item.memberId == item.landlord.id){
                return {
                    id: "",
                    name: item.name,
                    portrait: item.portrait,
                    nickname:"房客"
                }
            }
            else{
                return {
                    id: item.landlord.id,
                    name: item.landlord.name,
                    portrait: item.landlord.cover,
                    nickname:"房東"
                }
            }
        },
        getMessage(item){
            return item.communications[item.communications.length-1]
        },
        goRoom(){
            this.$router.push({
                path: `/room/${this.mes.landlord.houseId}`,
            });
        },
        scrollToBottom(){
            this.$nextTick(()=>{
                let offBody = document.querySelector('.offcanvas-body');
                let body = document.querySelector('.body');
                if(offBody != null){
                    offBody.scrollTop = offBody.scrollHeight;
                }
                if(body != null){
                    body.scrollTop = body.scrollHeight;
                }
            })
        }
    },
}
</script>

<style lang="scss" scoped>
.brief{
    cursor: pointer;
    &:hover{
        background-color: rgb(226, 222, 222);
    }
    &.active{
        background-color: rgb(226, 222, 222);
    }
}
.messageBox{
    text-align: start;
    border-bottom: 1px solid rgb(209, 206, 206);
    color: #000;
    text-decoration: none;
    .img{
        img{
            width: 100%;
            vertical-align: bottom;
            object-fit: cover;
            border-radius: 50%;
        }
    }
    .text{
        padding-left: 0.5rem;
        div{
            margin: 0.5rem 0;
        }
        .name,
        .bookingDate{
            font-size: 0.9rem;
        }
    }
    .info{
        text-align: center;
        .uncheck{
            margin-top: 0.3rem;
            height: 1.8rem;
            width: 1.8rem;
            line-height: 1.8rem;
            font-weight: 700;
            background-color: #ff385c;
            border-radius: 50%;
            color: #fff;
        }
    }
}
#offcanvasRight{
    border-left: none;
    width: 100%;
    img{
        width: 1.5rem;
    }
    .title{
        text-align: start;
        margin-left: 1rem;
        h2{
            font-weight: 700;
        }
    }
    .mix{
        color: #000;
        text-decoration: none;
        border-top: 1px solid rgba(123, 123, 123, 0.2);
        border-bottom: 1px solid rgba(123, 123, 123, 0.2);
        img{
            width: 2.5rem;
            height: 2.5rem;
            vertical-align: bottom;
            object-fit: cover;
            border-radius: 8px;
        }
        h3{
            font-weight: 900;
            text-decoration: underline !important;
            margin-bottom: 0.5em;
        }
        .bookingDate{
            font-size: 0.9rem;
        }
    }
    .offcanvas-footer{
        background-color: #fff;
        height: 6rem;
        display: flex;
        align-items: center;
        justify-content: center;
        input{
            border-radius: 30px;
            border: 1px solid rgb(123, 123, 123);
            padding: .7rem .5rem;
            width: 85vw;
            font-size: 1.1rem;
            &:focus{
                border: 2px solid rgb(0, 0, 0);
            }
        }
    }
}
@media screen and (min-width: 768px){
    .brief{
        padding: 0 0.8rem;
    }
}
</style>