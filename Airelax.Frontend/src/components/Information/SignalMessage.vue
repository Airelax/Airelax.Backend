<template>
    <div v-for="(item,index) in  $store.state.signalCommunications" :key="index" class="main">
        <div class="host" v-if="item.senderId==message.memberId">
            <div v-if="message.memberId==message.landlord.id" class="d-flex py-2 py-md-1 justify-content-end">
                <div class="align-self-end">
                    <p style="font-size:.3rem; text-align:end;">{{splitDate(item.time,0,1)}}-{{splitDate(item.time,0,2)}}</p>
                    <p style="font-size:.3rem; text-align:end;">{{splitTime(item.time,1,0)}}:{{splitTime(item.time,1,1)}}</p>{{$store.state.messages}}
                    <p v-if="index < $store.state.signalCommunications.length - $store.state.unreadCount" style="font-size:.3rem; text-align:end;">已讀</p>
                </div>
                <span>{{item.content}}</span>
                <div>
                    <img :src="message.landlord.cover">
                    <p>{{message.landlord.name}}</p>
                </div>
            </div> 
            <div v-else class="d-flex py-2 py-md-1 justify-content-end">
                <div class="align-self-end">
                    <p style="font-size:.3rem; text-align:end;">{{splitDate(item.time,0,1)}}-{{splitDate(item.time,0,2)}}</p>
                    <p style="font-size:.3rem; text-align:end;">{{splitTime(item.time,1,0)}}:{{splitTime(item.time,1,1)}}</p>{{$store.state.messages}}
                    <p v-if="index < $store.state.signalCommunications.length - $store.state.unreadCount" style="font-size:.3rem; text-align:end;">已讀</p>
                </div>
                <span>{{item.content}}</span>
                <div>
                    <img :src="message.portrait">
                    <p>{{message.name}}</p>
                </div>
            </div>
        </div>
        <div class="guest" v-else>
            <div v-if="message.memberId==message.landlord.id" class="d-flex py-2 py-md-1 justify-content-start">
                <div>
                    <img :src="message.portrait">
                    <p>{{message.name}}</p>
                </div>
                <span>{{item.content}}</span>
                <div class="align-self-end">
                    <p style="font-size:.3rem; text-align:start;">{{splitDate(item.time,0,1)}}-{{splitDate(item.time,0,2)}}</p>
                    <p style="font-size:.3rem; text-align:end;">{{splitTime(item.time,1,0)}}:{{splitTime(item.time,1,1)}}</p>
                </div>
            </div>
            <div v-else class="d-flex py-2 py-md-1 justify-content-start">
                <div>
                    <img :src="message.landlord.cover">
                    <p>{{message.landlord.name}}</p>
                </div>
                <span>{{item.content}}</span>
                <div class="align-self-end">
                    <p style="font-size:.3rem; text-align:start;">{{splitDate(item.time,0,1)}}-{{splitDate(item.time,0,2)}}</p>
                    <p style="font-size:.3rem; text-align:end;">{{splitTime(item.time,1,0)}}:{{splitTime(item.time,1,1)}}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props:["message"],
    methods:{
        splitDate(item,first,second){
            return item.split('T')[first].split('-')[second]
        },
        splitTime(item,first,second){
            return item.split('T')[first].split(':')[second]
        }
    }
}
</script>

<style lang="scss" scoped>
img{
    width: 2rem;
    border-radius: 50%;
}
span{
    text-align: start;
    max-width:60%;
    padding: .8rem;
    display: inline-block;
    background-color: #d8d8d8;
    border-radius: 12px;
    margin: 0 0.5rem;
    line-height: 1.3rem;
}
@media screen and (min-width: 768px){
    .main{
        padding: 1rem 2rem;
    }
    span{
        max-width: 74%;
    }
}
</style>