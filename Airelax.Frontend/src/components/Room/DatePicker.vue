<template>
    <div>
        <h2 v-if="fullWidth<768">你的旅程</h2>
        <div class="choice">
            <div class="pick-date">
                <div class="search-div in-date" data-bs-toggle="offcanvas" data-bs-target="#Bottom" aria-controls="Bottom" @click="isDateShow=true">
                    <span class="search-title">入住</span>
                    <div>
                        <div class="placeholder" v-if="Object.keys($store.state.date).length == 0" >選取日期</div>
                        <div class="placeholder" v-else>{{$store.state.date.start}}</div>
                    </div>
                </div>
                <div class="search-div out-date" data-bs-toggle="offcanvas" data-bs-target="#Bottom" aria-controls="Bottom" @click="isDateShow=true">
                    <span class="search-title">退房</span>
                    <div>
                        <div class="placeholder" v-if="Object.keys($store.state.date).length == 0">選取日期</div>
                        <div class="placeholder" v-else>{{$store.state.date.end}}</div>
                    </div>
                </div>
            </div>
            <div class="people search-div" data-bs-toggle="offcanvas" data-bs-target="#Bottom" aria-controls="Bottom" @click="isPeopleShow=true">
                <span class="search-title">房客</span>
                <div>
                    <div class="placeholder" v-if="$store.state.adult==0">新增人數</div>
                    <div class="placeholder" v-else>{{$store.state.adult+$store.state.child}}位,{{$store.state.toddler}}名嬰幼兒</div>
                </div>
            </div>
        </div>
        <div class="offcanvas offcanvas-bottom" tabindex="-1" id="Bottom" aria-labelledby="offcanvasBottomLabel" data-bs-backdrop="false">
            <div class="offcanvas-header">
                <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close" @click="invisible"></button>
            </div>
            <div class="offcanvas-body small">
                <keep-alive>
                    <Date v-if="isDateShow"></Date>
                </keep-alive>
                <keep-alive>
                    <People v-if="isPeopleShow"></People>
                </keep-alive>
        
            </div>
        </div>
    </div>
</template>

<script>
import Date from './Date';
import People from './People';
export default {
    data(){
        return{
            isDateShow: false,
            isPeopleShow: false,
            fullWidth: 0
        }
    },
    methods:{
        invisible() {
            this.isDateShow = false;
            this.isPeopleShow = false;
        }
    },watch:{
        fullWidth(val){
            this.fullWidth = val;
        }
    },
    mounted() {
        const vm = this;
        this.fullWidth = document.body.clientWidth;
        window.addEventListener("resize", function() {
            vm.fullWidth = document.body.clientWidth;
        })
    },
    components:{
        Date,
        People
    }
}
</script>

<style lang="scss" scoped>
h2{
    font-size: 1.5rem;
    font-weight: 700;
    margin-bottom: 2rem;
}
.choice{
    border: 1px solid #717171;
    border-radius: 8px;
    margin: 1rem 0;
    cursor: pointer;
    overflow: hidden;
    .pick-date{
        display: flex;
        justify-content: space-between;
        border-bottom: 1px solid #717171;
        .in-date{
            border-right: 1px solid #717171;
        }
    }
    .search-div {
        width: 50%;
        padding: .5rem 0;
        padding-left: 0.5rem;
        transition: .3s;
        &:hover{
            background-color: #ddd9d9;
        }
        span{
            font-weight: 700;
        }
        .placeholder{
            color: #717171;
            margin: 0.1rem 0;
        }
    }
    .people{
        width: 100%;
    }
}
.offcanvas{
    height: 81vh;
    border-radius: 18px;
    border: 2px solid rgb(117, 116, 116);
    box-shadow: 5px 5px 10px rgb(209, 206, 206);

}
@media screen and (min-width:768px){
    .offcanvas{
        margin: 2rem 20rem;
    }
}
</style>