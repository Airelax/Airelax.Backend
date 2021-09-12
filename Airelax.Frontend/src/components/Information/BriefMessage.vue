<template>
    <div v-for="item in messages" :key="item.id">
        <div class="brief" @click="sendData(item)">
            <a v-if="width<768" class="messageBox" data-bs-toggle="offcanvas" href="#offcanvasRight" role="button" aria-controls="offcanvasRight">
                <div class="row d-flex align-items-center py-2">
                    <div class="col-2">
                        <div class="img"><img :src="getReceiver(item).portrait"></div>
                    </div>
                    <div class="col-8 text">
                        <div class="name">[{{getReceiver(item).nickname}}] {{getReceiver(item).name}}</div>
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
                        <div class="name">[{{getReceiver(item).nickname}}] {{getReceiver(item).name}}</div>
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
                    <div>回覆時間：1 小時</div>{{count}}
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
    props:['messages'],
    inject: ["reload"],
    data(){
        return{
            mes:{},
            receiver: "",
            msg: "",
            count: 0
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
        this.$store.state.connection = connection;
        this.$store.state.readedCount = 0;
        this.$store.state.readed = false;
        connection.on("ReceiveMessage",function(user,message){
            let com = {
                senderId: user==vm.mes.landlord.name?vm.mes.landlord.id:(vm.mes.gusetId == vm.mes.landlord.id?vm.mes.memberId:vm.mes.gusetId),
                receiverId: user!=vm.mes.landlord.name?vm.mes.landlord.id:(vm.mes.gusetId == vm.mes.landlord.id?vm.mes.memberId:vm.mes.gusetId),
                content: message,
                time: moment(new Date()).format('YYYY-MM-DD[T]HH:mm:ss')
            }
            
            let ontime = {
                MemberId: vm.mes.memberId,
                OtherId: vm.mes.gusetId
            }
            console.log("ABC")
            vm.$store.state.signalCommunications.push(com);

            // axios.put(`/api/messages/${vm.$route.params.memberId}/content`, com,{
            // headers: {
            //     "Access-Control-Allow-Origin": "*",
            // }}).then(function (res) {
            //         console.log(res.data)
            //         axios.put(`/api/messages/${vm.$route.params.memberId}/ontime`, ontime,{
            //             headers: {
            //                 "Access-Control-Allow-Origin": "*",
            //             }}).then(function (res) {
            //                     console.log(res.data)
            //                     connection.invoke("getCount", vm.mes.connectString).then(x=>{
            //                         vm.count = x
            //                         if(vm.count==2){
            //                             vm.mes.memberTwoStatus = 0;
            //                             vm.$store.state.readed = true;
            //                         }
            //                         else {
            //                             vm.$store.state.readed = false;
            //                         }
            //                     })
            //         })
            // })

            axios.put(`/api/messages/${vm.$route.params.memberId}/content`, com,{
            headers: {
                "Access-Control-Allow-Origin": "*",
            }}).then(function (res) {
                    console.log(res.data)
                    connection.invoke("getCount", vm.mes.connectString).then(x=>{
                        vm.count = x
                        if(vm.count==2){
                            axios.put(`/api/messages/${vm.$route.params.memberId}/status`, ontime,{
                            headers: {
                                "Access-Control-Allow-Origin": "*",
                            }}).then(function (res) {
                                    console.log(res.data)
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
                            })
                            vm.$store.state.readed = false;
                        }
                    })
            })



            vm.scrollToBottom();
        })
    },
    updated(){
        this.scrollToBottom();
    },
    methods:{
        useAxios(com){
            axios.put(`/api/messages/${this.$route.params.memberId}/content`, com,{
            headers: {
                "Access-Control-Allow-Origin": "*",
            }}).then(function (res) {
                    console.log(res.data)
                }).catch(err=>{console.log(err)})
        },
        updateStatus(com){
            axios.put(`/api/messages/${this.$route.params.memberId}/status`, com,{
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
            connection.invoke("SendMessageToGroup",this.mes.connectString, this.mes.memberId == this.mes.landlord.id? this.mes.landlord.name:this.mes.name, this.msg ).catch(function (err) {
                return console.error(err.toString());
            });
            connection.invoke("getCount",this.mes.connectString).then(x=>this.count = x);
            this.msg="";
        },
        removeJoin(){
            var vm = this;
            connection.invoke("RemoveGroup", this.mes.connectString).catch(function (err) {
                return console.error(err.toString());
            });
            this.$nextTick(()=>{
                connection.invoke("getCount", this.mes.connectString).then(x=>vm.count = x)
            });
            connection.off("ReceiveMessage");
            this.reload();
        },
        sendData(item){
            var vm = this;

            if(this.width>768 && Object.keys(this.$store.state.message).length != 0) {
                connection.invoke("RemoveGroup", this.$store.state.message.connectString).catch(function (err) {
                    return console.error(err.toString());
                });
                connection.off("ReceiveMessage");

                // connection.on("ReceiveMessage",function(user,message){
                //     let com = {
                //         senderId: (user==vm.mes.landlord.name?vm.mes.landlord.id:vm.mes.gusetId ),
                //         receiverId: (user!=vm.mes.landlord.name?vm.mes.landlord.id:vm.mes.gusetId ),
                //         content: message,
                //         time: moment(new Date()).format('YYYY-MM-DD[T]HH:mm:ss')
                //     }
                //     vm.$store.state.signalCommunications.push(com);
                //     vm.useAxios(com)
                //     vm.scrollToBottom();
                // })
            }

            this.mes = item;
            this.$store.state.message = item;

            // joinGroup
            this.$nextTick(()=>{
                connection.invoke("AddGroup", item.connectString).catch(function (err) {
                    return console.error(err.toString());
                });
            })
            this.$nextTick(()=>{
                connection.invoke("getCount", item.connectString).then(x=>vm.count = x)
            });

            //已讀
            let com = {
                MemberId: item.memberId,
                OtherId: item.gusetId
            }
            if(item.memberId == item.landlord.id){
                if(item.memberOneStatus != 0) this.updateStatus(com);
            }
            else{
                if(item.memberTwoStatus != 0) this.updateStatus(com);
            }

            if(this.width>768) this.reload();
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