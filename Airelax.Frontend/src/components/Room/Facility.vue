<template>
    <div class="main">
        <h2>有提供的設備與服務</h2>
        <ul>
            <div v-for="item in detail.provide" :key="item" class="d-flex align-items-center fac">
                <li v-if="checkFacilityItem(item)">
                    <img :src="getFacilityIcon(item)" style="width:1.5rem;">
                    <span>{{getFacilityName(item)}}</span>
                </li>
            </div>
        </ul>
        <h3>不提供</h3>
        <ul>
            <div v-for="item in detail.notProvide" :key="item" class="d-flex align-items-center fac">
                <li v-if="checkFacilityItem(item)">
                    <img :src="getFacilityIcon(item)" style="width:1.5rem;">
                    <span>{{getFacilityName(item)}}</span>
                </li>
            </div>
        </ul>
    </div>
</template>

<script>
export default {
  props:["detail","facilitySetting"],
  methods:{
        checkFacilityItem(item){
            let temp = this.facilitySetting.facilities.filter(x=>x.mapping == item)
            if(temp.length == 0) return false
            else return true
        },
        getFacilityIcon(item){
            let icon = this.facilitySetting.facilities.filter(x=>x.mapping == item)
            if(icon.length != 0 && icon[0].img !=""){
                return icon[0].img;
            }
            else{
                return require("@/assets/pic/HonorIcons/Star.svg");
            }
        },
        getFacilityName(item){
            let icon = this.facilitySetting.facilities.filter(x=>x.mapping == item)
            if(icon.length != 0){
                return icon[0].chinese;
            }
        },
  }
}
</script>

<style lang="scss" scoped>
.main{
    margin: 0 1.5rem;
    text-align: left;
    h2{
        font-size: 1.6rem;
        font-weight: 700;
    }
    h3{
        font-size: 1.6rem;
        font-weight: 700;
        margin-top: 2rem;
    }
    .fac{
        border-bottom: 1px solid rgba(209, 206, 206,.5);
    }
    ul{
        li{
           display: flex;
           align-items: center;
           padding: 1.7rem 0;
           font-size: 1.1rem;
           span{
               display: block;
               margin-left: 1rem;
           }
        }
        & .fac:last-child{
            border-bottom: none;
        }
    }
}
</style>