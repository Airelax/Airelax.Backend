<template>
    <div class="main">
        <div :class="{ active: i%3 === 0,'pic':true}" v-for="(item,i) in detail" :key="i" :num="i" @click="changeModal">
            <img :src="item">
        </div>
        <transition name="fade">
          <OnePicture v-if="isModalShow" :onePic="pic" :index="index" :total="length" @update='isModalShow = !isModalShow'></OnePicture>
        </transition>
    </div>
</template>

<script>
import OnePicture from './OnePicture';
export default {
    props:["detail"],
    data(){
        return{
            isModalShow: false,
            pic:"",
            index: 0,
            length: 0
        }
    },
    methods:{
        changeModal(e){
            this.isModalShow = !this.isModalShow;
            this.pic = e.target.getAttribute('src');
            this.index = e.target.parentNode.getAttribute('num');
            this.length = this.detail.length;
        }
    },
    components:{OnePicture}
}
</script>

<style lang="scss" scoped>
.main{
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    .pic{
        width: 49%;
        margin-bottom: .5rem;
        cursor: pointer;
        position: relative;
        img{
            width: 100%;
            height: 100%;
            object-fit:cover;
        }
    }
    .active{
        width: 100%;
    }
}
.fade-enter {
  opacity: 0;
}
.fade-enter-active,
.fade-leave-active {
  transition: all 1s;
}
.fade-leave-to {
  opacity: 0;
}

@media screen and (min-width:768px){
    .main{
        overflow: hidden;
        padding: 0 20rem;
    }
}
</style>