<template>
    <div class="main">
        <div class="txt">
            <h2>空間介紹</h2>
            <p>{{detail.houseDescription}}</p>
            <div v-if="detail.spaceDescription != null">
                <h3>房源空間</h3>
                <p>{{detail.spaceDescription}}</p>
            </div>
            <div v-if="detail.guestPermission != null">
                <h3>房客使用權限</h3>
                <p>{{detail.guestPermission}}</p>
            </div>
            <div v-if="detail.others != null">
                <h3>其他注意事項</h3>
                <p>{{detail.others}}</p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  props:["detail"]
}
</script>

<style lang="scss" scoped>
.txt{
    margin: 0 1.5rem;
    text-align: left;
    h2{
        font-size: 2rem;
        font-weight: 700;
    }
    h3{
        font-size: 1.3rem;
        font-weight: 700;
    }
    p{
        margin: 0.5rem 0;
        font-size: 1rem;
        margin-bottom: 1.5rem;
        line-height: 1.3rem;
    }
}
</style>