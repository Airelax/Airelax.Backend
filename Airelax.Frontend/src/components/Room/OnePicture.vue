<template>
    <div class="onePicShow">
        <button @click="disappear">﹤</button>
        <span>{{Number(index)+1}}/{{total}}</span>
        <div class="img"><img :src="onePic"></div>
    </div>
</template>

<script>
export default {
    props:["onePic","index","total"],
    methods:{
        disappear(){
            document.querySelector('.onePicShow').style.opacity = '0';
            this.$emit('update')
        }
    }
}
</script>

<style lang="scss" scoped>
.onePicShow{
    transition: 1s ease-in;
    position: fixed;
    width: 100vw;
    height: 100vh;
    z-index: 20;
    left: 0;
    top: 0;
    background-color: #000;
    display: flex;
    align-items: center;
    img{
        width: 100%;
    }
    button{
        position: absolute;
        top: 3%;
        left: 3%;
        border: none;
        color: #fff;
        background-color: #000;
        color: #fff;
        font-size: 2rem;
    }
    span{
        position: absolute;
        top: 4%;
        right: 45%;
        font-size: 1.2rem;
        color: #fff;
    }
}
@media screen and (min-width:768px){
    .onePicShow{
        padding: 10rem;
        span{
            top: 93%;
            right: 3%;
            font-size: 1.2rem;
            color: #fff;
        }
    }
}
</style>