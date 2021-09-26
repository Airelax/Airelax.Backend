<template>
    <div class="checkbox row">
        <div class="col-md-3 brief">
            <h1 v-if="width<768">收件匣</h1>
            <h1 v-else>訊息</h1>
            <div class="briefmessage">
                <Brief></Brief>
            </div>
        </div>
        <div v-if="width>768" class="col-md-9">
            <MainMessage></MainMessage>
        </div>
    </div>
</template>

<script>
import Brief from '../components/Information/BriefMessage';
import MainMessage from '../components/Information/MainMessage';

export default {
    components:{Brief, MainMessage},
    computed:{
        width(){
            return this.$store.state.fullWidth;
        }
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