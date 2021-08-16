<template>
    <div class="main">
        <h2>有提供的設備與服務</h2>
        <ul>
            <li v-for="item in detail.provide" :key="item">
                <i class="fas fa-tv"></i> <span> {{item}} 電視</span>
            </li>
        </ul>
        <h3>不提供</h3>
        <ul>
            <li v-for="item in detail.provide" :key="item">
                <i class="fas fa-tv"></i> <span> {{item}} 不提供</span>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
  props:["detail"],
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
        font-size: 1.2rem;
        font-weight: 700;
        margin-top: 2rem;
    }
    ul{
        li{
           padding: 1.7rem 0;
           font-size: 1.1rem;
           border-bottom: 1px solid rgba(209, 206, 206,.5);
           span{
               margin-left: 1rem;
           }
        }
    }
}
</style>