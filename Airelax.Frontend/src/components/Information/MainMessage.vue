<template>
    <div class="main" v-if="Object.keys($store.state.message).length != 0">
        <div class=" message" id="message">
            <div class="d-flex justify-content-between align-items-center top">
                <div class="title ms-4">
                    <div class="d-flex">
                        <h2 id="offcanvasRightLabel" v-if="Object.keys($store.state.message).length != 0">[{{getReceiver($store.state.message).nickname}}] {{getReceiver($store.state.message).name}}</h2>
                        <span v-if="$store.state.onlineCount==2" class="ms-2"><i class="fas fa-circle text-success"></i> (上線中)</span>
                        <span v-else class="ms-2"><i class="fas fa-circle text-danger"></i> (未上線)</span>
                    </div>
                    <div>回覆時間：1 小時</div>
                </div>
                <button class="me-4" @click="change" id="btn-detail">隱藏詳情</button>
            </div>
            <div class="body">
                <div class="talk">
                    <Talk :message="$store.state.message"></Talk>
                    <Signal :message="$store.state.message"></Signal>
                </div>
            </div>
            <div class="footer">
                <div class="input"><input type="text" v-model="msg" placeholder="輸入訊息" @keydown.enter="sengMsg"></div>
            </div>
        </div>
        <div class=" detail" id="detail">
            <div class="top d-flex align-items-center justify-content-between">
                <h2 class="ms-2">詳情</h2>
                <button type="button" class="btn-close text-reset me-2" @click="close"></button>
            </div>
            <div class="room-detail p-4">
                <div class="img"><img :src="$store.state.message.pictures[0]"></div>
                <div class="cnaOrder py-3">
                    <h3>該房源在所選的日期已無法預訂</h3>
                    <button class="btn w-100 border-dark my-2 py-3" @click="goSearch($store.state.message.tourDetail.town)">繼續搜尋其他房源</button>
                </div>
                <div class="tour text-start py-5">
                    <div class="title">旅程詳情</div>
                    <a href="#" class="house row d-flex align-items-center" @click.prevent="goRoom">
                        <div class="col-10">
                            <div class="house-title" style="line-height:1.3rem;">{{$store.state.message.tourDetail.title}}</div>
                            <div class="location">整套住宅 · {{$store.state.message.tourDetail.town}},  {{$store.state.message.tourDetail.city}},  {{$store.state.message.tourDetail.country}}</div>
                        </div>
                        <div class="col-2 text-end">
                            ﹥
                        </div>
                    </a>
                    <a  :href="'/MemberInfo/'+ $store.state.message.landlord.id" class="landlord  d-flex align-items-center justify-content-between">
                        <div >
                            <div class="landlord-name">房東：{{$store.state.message.landlord.name}}</div>
                        </div>
                        <div>
                            <div class="img"><img :src="$store.state.message.landlord.cover"></div>
                        </div>
                    </a>
                    <div class="checkin">
                        <p>入住</p>
                        <div class="time">{{$store.state.message.tourDetail.startDate.split('T')[0]}}</div>
                    </div>
                    <div class="checkout">
                        <p>退房</p>
                        <div class="time">{{$store.state.message.tourDetail.endDate.split('T')[0]}}</div>
                    </div>
                </div>
                <div class="price text-start">
                    <div class="title">付款詳情</div>
                    <div class="customer">
                        <p>{{getPrice($store.state.message.origin)}} x {{nightCount}}晚</p>
                        <div class="number">${{getPrice($store.state.message.origin*nightCount)}}</div>
                    </div>
                    <div class="clean">
                        <p>清潔費</p>
                        <div class="number">${{getPrice($store.state.message.paymentDetail.serviceFee)}}</div>
                    </div>
                    <div class="service">
                        <p>服務費</p>
                        <div class="number">${{getPrice($store.state.message.paymentDetail.cleanFee)}}</div>
                    </div>
                    <div class="tax">
                        <p>稅款</p>
                        <div class="number">${{getPrice($store.state.message.paymentDetail.taxFee)}}</div>
                    </div>
                    <div class="total">
                        <p>總價</p>
                        <div class="number">${{totalPrice()}}</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Talk from '../Information/Talk';
import Signal from '../Information/SignalMessage';

export default {
    components:{Talk, Signal},
    data(){
        return{
            isClose: false,
            nightCount: 0,
            msg: ""
        }
    },
    methods:{
        sengMsg(){
            var vm = this;
            vm.$store.state.connection.invoke("SendMessageToGroup",vm.$store.state.message.connectString, JSON.stringify(vm.$store.state.message), vm.msg )
            vm.scrollToBottom();
            vm.msg="";
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
        change(){
            let detail = document.getElementById('detail');
            let message = document.getElementById('message');
            let detailBtn = document.getElementById('btn-detail');
            let talk = document.querySelector('.talk');
            this.isClose = !this.isClose;
            if(this.isClose){
                detailBtn.innerText = '了解詳情';
                detail.style.width = '0';
                message.style.width = '100%';
                talk.style.padding = "0 14vw";
                detail.addEventListener('transitionend',(event)=>{
                    event.target.style.opacity = '0';
                    event.target.style.height = '0';
                });
                
            }
            else{
                detailBtn.innerText = '隱藏詳情';
                detail.style.width = '40%';
                message.style.width = '60%';
                talk.style.padding = "0";
                detail.addEventListener('transitionend',(event)=>{
                    event.target.style.height = '100%';
                    event.target.style.opacity = '100';
                });
            }
        },  
        close(){
            this.change()
        },
        getDate(x){
            return Date.parse(x);
        },
        Diff(){
            if(Object.keys(this.$store.state.message).length == 0) return
            let diff = this.getDate(this.$store.state.message.tourDetail.startDate.split('T')[0])-this.getDate(this.$store.state.message.tourDetail.endDate.split('T')[0]);
            this.nightCount =  Math.abs(diff)/1000/24/60/60;
        },
        totalPrice(){
            return (this.$store.getters.TotalPrice + this.$store.state.message.origin*this.nightCount).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        },
        getPrice(x){
            return x.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        },
        scrollToBottom(){
            this.$nextTick(()=>{
                let body = document.querySelector('.body');
                if(body == null) return
                body.scrollTop = body.scrollHeight;
            })
        },
        goSearch(x){
            this.$router.push({
                path: "/search",
                query: {
                location: x
                },
            });
        },
        goRoom(){
            this.$router.push({
                path: `/room/${this.$store.state.message.landlord.houseId}`,
            });
        }
    },
    mounted(){
        this.Diff();
        this.scrollToBottom();
    }
}
</script>

<style lang="scss" scoped>
.main{
    height: 100%;
    width: 100%;
    display: flex;
    overflow: hidden;
    .message{
        width: 60%;
        border-right: 1px solid rgb(209, 206, 206);
        .top{
            padding: .9rem;
            border-bottom: 1px solid rgb(209, 206, 206);
            .title{
                text-align: start;
                margin-left: 1rem;
                h2{
                    font-weight: 700;
                }
            }
            button{
                border-radius:30px;
                border: 2px solid rgb(150, 150, 150);
                background-color: rgb(247, 247, 247);
                font-size: 0.6rem;
                padding: .6rem 1rem;
                &:hover{
                    border: 2px solid #000;
                }
            }
        }
        .body{
            height: 69vh;
            overflow-y: scroll;
        }
        .footer{
            background-color: #fff;
            height: 4rem;
            display: flex;
            align-items: center;
            justify-content: center;
            input{
                border-radius: 30px;
                border: 1px solid rgb(123, 123, 123);
                padding: .7rem .5rem;
                width: 40vw;
                font-size: 1.1rem;
                &:focus{
                    border: 2px solid rgb(0, 0, 0);
                }
            }
        }
    }
    .detail{
        width: 40%;
        transition: .3s;
        .top{
            padding: 1.25rem .8rem;
            border-bottom: 1px solid rgb(209, 206, 206);
            h2{
                font-weight: 700;
                font-size: 1.2rem;
            }
        }
        .room-detail{
            height: 78vh;
            overflow-y: scroll;
            .img{
                height: 15rem;
                img{
                    width: 100%;
                    height: 100%;
                    object-fit: cover;
                    border-radius: 8px;
                }
            }
            .cnaOrder{
                text-align: start;
                border-bottom: 1px solid rgb(209, 206, 206);
                h3{
                    font-size: 1.3rem;
                    font-weight: 700;
                }
                button{
                    font-weight: 700;
                    &:hover{
                        background-color: rgb(236, 236, 236);
                    }
                }
            }
            .tour{
                .title{
                    font-size: 1.8rem;
                    font-weight: 700;
                }
                .landlord,
                .house{
                    color: #000;
                    text-decoration: none;
                    padding: 1.5rem 0;
                    transition: .3s;
                    border-bottom: 1px solid rgb(209, 206, 206);
                    &:hover{
                        background-color: rgb(236, 236, 236);
                    }
                    .location{
                        margin: 0.5rem 0;
                        line-height: 1.2rem;
                        font-size: 0.9rem;
                    }
                    .text-end{
                        font-size: 2rem;
                    }
                }
                & > div{
                    display: flex;
                    justify-content: space-between;
                    align-items: center;
                    padding: 1.5rem 0;
                    border-bottom: 1px solid rgb(209, 206, 206);
                }
                .img{
                    width: 3rem;
                    height: 3rem;
                    img{
                        border-radius: 50%;
                        object-fit: cover;
                    }
                }
            }
            .price{
                .title{
                    font-size: 1.8rem;
                    font-weight: 700;
                }
                & > div{
                    display: flex;
                    justify-content: space-between;
                    align-items: center;
                    padding: 1.5rem 0;
                    border-bottom: 1px solid rgb(209, 206, 206);
                }
                .total{
                    font-size: 1.2rem;
                    font-weight: 700;
                    border-bottom: none;
                }
            }
        }
    }
}
</style>