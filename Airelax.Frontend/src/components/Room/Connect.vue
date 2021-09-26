<template>
    <div class="detail">
        <div class="txt">
            <p>聯絡{{detail.name}}</p>
            <span>通常會在 1 小時內回覆</span>
        </div>
        <div class="img">
            <img :src="detail.cover" style="width: 3rem;"/>
        </div>
    </div>
    <div class="content">
        <h2 class="question">旅客常見問題</h2>
        <h2>前往那裡</h2>
        <ul>
            <li>此房源的入住時間從下午{{rule.checkinTime}}開始，退房時間為上午{{rule.checkoutTime}}。</li>
        </ul>
        <h2>房源詳情與守則</h2>
        <ul>
            <li v-if="!rule.allowBaby || !rule.allowChild">不適合兒童和嬰幼兒</li>
            <li v-if="rule.allowPet">允許攜帶寵物</li>
            <li v-if="!rule.allowPet">不允許攜帶寵物</li>
            <li v-if="!rule.allowParty">不允許舉辦聚會和活動</li>
            <li v-if="!rule.allowSmoke">禁止吸煙</li>
        </ul>
        <h2>價格和可訂狀態</h2>
        <ul>
            <li>期限內可獲得全額退款</li>
        </ul>
        <textarea placeholder="請輸入訊息" id="messageContent"></textarea>
    </div>
</template>

<script>
export default {
    props:["detail","rule"]
}
</script>

<style lang="scss" scoped>
.detail{
    display: flex;
    margin: 0 1.5rem;
    justify-content: space-between;
    text-align: left;
    padding-bottom: 2rem;
    border-bottom: 1px solid rgb(209, 206, 206);
    .txt{
        font-weight: 700;
        p{
            margin: 0.6rem 0;
            font-size: 1.5rem;
        }
        span{
            color: #717171;
            font-size: 0.9rem;
        }
    }
    .img{
        display: flex;
        img{
            margin: auto;
            border-radius: 50%;
        }
    }
}
.content{
    text-align: left;
    margin: 0 1.5rem;
    h2{
      font-size: 1.2rem;
      font-weight: 700;
      margin: 2rem 0;
    }
    .question{
      font-size: 1.5rem;
    }
    ul{
        list-style-type: disc;
        li{
            margin: 1rem 1.5rem;
            font-size: 1.1rem;
            line-height: 1.5rem;
        }
    }
    textarea{
        width: 100%;
        margin: 0 .1rem;
        height: 30vh;
    }
}
</style>