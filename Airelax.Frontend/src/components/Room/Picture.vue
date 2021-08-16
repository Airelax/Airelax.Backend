<template>
    <div>
        <div class="main" v-if="fullWidth<768">
            <div class="pic" v-for="(item,i) in fourBlock" :key="i">
                <img :src="item">
            </div>
            <div class="count">1/{{pic.length}}</div>
        </div>
        <div class="main-lg" v-if="fullWidth > 768" @click="isCanvasShow=true" data-bs-toggle="offcanvas" data-bs-target="#BottomPic" aria-controls="Bottom">
            <div class="picture">
                <img :src="pic[0]">
            </div>
            <div class="side">
                <div v-for="(item,i) in fiveBlock" :key="i" :class="{pic:true}">
                    <img :src="item">
                </div>
            </div>
            <div class="md-show"><img src="@/assets/image/Room/icon/nine-dots.svg">顯示全部照片</div>
        </div>

        <div class="offcanvas offcanvas-bottom" tabindex="-1" id="BottomPic" aria-labelledby="offcanvasBottomLabel" data-bs-backdrop="false">
            <div class="offcanvas-header">
                <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close" @click="invisible"></button>
            </div>
            <div class="offcanvas-body small">
                <AllPicture v-if="isCanvasShow" :detail="pic"></AllPicture>
            </div>
        </div>

    </div>
</template>

<script>
import AllPicture from  './AllPicture';
export default {
  data(){
      return{
          fullWidth: 0,
          isCanvasShow: false
      }
  },
  methods:{
      invisible(){
          this.isCanvasShow = false;
      }
  },
  props:[
      "pic"
  ],
  computed:{
    fourBlock(){
        return this.pic.filter(function(value, index){
            return index < 4;
        })
    },
    fiveBlock(){
        return this.pic.filter(function(value, index){
            return index !== 0 && index < 5;
        })
    }
  },
  watch:{
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
  components:{AllPicture}
}
</script>

<style lang="scss" scoped>
.main{
    position: relative;
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    .pic{
        width: 50%;
        position: relative;
        cursor: pointer;
        &:before {
            content: '';
            width: 100%;
            height: 100%;
            display: block;
            position: absolute;
            top: 0;
            left: 0;
            background-color: rgba(0, 0, 0, 0);
            transition: .3s;
        }
        &:hover:before {
            background-color: rgba(0, 0, 0, 0.2);
        }
        img{
            width: 100%;
            height: 100%;
            object-fit:cover;
        }
    }
    .count{
        background-color: rgba($color: #000000, $alpha: 0.7);
        color: #fff;
        padding: 0.3rem .7rem;
        border-radius: 5px;
        position: absolute;
        right: 1rem;
        bottom: 1.2rem;
    }
}
@media screen and (min-width:768px){
    .main-lg{
        border-radius: 18px;
        overflow: hidden;
        display: flex;
        justify-content: space-between;
        position: relative;
        .picture{
            position: relative;
            width: 49.7%;
            cursor: pointer;
            &:before {
                content: '';
                width: 100%;
                height: 100%;
                display: block;
                position: absolute;
                top: 0;
                left: 0;
                background-color: rgba(0, 0, 0, 0);
                transition: .3s;
            }
            &:hover:before {
                background-color: rgba(0, 0, 0, 0.3);
            }
            img{
                width: 100%;
                object-fit: cover;
                vertical-align: bottom;
            }
        }
        .side{
            width: 49.7%;
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
            .pic{
                width: 49.5%;
                cursor: pointer;
                position: relative;
                &:nth-child(1),
                &:nth-child(2)
                {
                    margin-bottom: .1rem;
                }
                &:nth-child(3),
                &:nth-child(4)
                {
                    margin-top: .1rem;
                }
                img{
                  width: 100%;
                }
                &:before {
                    content: '';
                    width: 100%;
                    height: 100%;
                    display: block;
                    position: absolute;
                    top: 0;
                    left: 0;
                    background-color: rgba(0, 0, 0, 0);
                    transition: .3s;
                }
                &:hover:before {
                    background-color: rgba(0, 0, 0, 0.3);
                }
            }
        }
        .md-show{
            font-weight: 700;
            position: absolute;
            right: 1.5rem;
            bottom: 1.5rem;
            background-color: #fff;
            border: 1px solid #000;
            padding: .5rem;
            display: flex;
            align-items: center;
            border-radius: 8px;
            cursor: pointer;
            &:hover{
                background-color: rgb(228, 225, 225);
            }
            img{
                width: .8rem;
                margin-right: 0.5rem;
            }
        }
    }
    .offcanvas{
        height: 100vh;
    }
}
@media screen and (min-width:1200px){
    .main-lg{
        height: 22rem;
    }
}
</style>