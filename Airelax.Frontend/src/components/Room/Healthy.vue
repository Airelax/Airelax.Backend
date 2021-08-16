<template>
    <div class="main">
        <h2>健康與安全</h2>
        <ul>
            <li><img src="@/assets/image/Room/icon/time.svg">承諾遵守 Airbnb 的深度清潔流程。</li>
            <li><img src="@/assets/image/Room/icon/spray.svg"><span>在新冠肺炎疫情大流行期間，所有用戶都必須閱讀和遵守 Airbnb 的社交距離指南和其他防疫指南。</span></li>
            <li><img src="@/assets/image/Room/icon/detect2.svg">一氧化碳警報器</li>
            <li><img src="@/assets/image/Room/icon/detect1.svg">煙霧警報器</li>
        </ul>
        <h3>您還必須確認</h3>
        <ul>
            <li><img src="@/assets/image/Room/icon/stair.svg">需要走樓梯</li>
            <li><img src="@/assets/image/Room/icon/card.svg">押金 - 如果您對房源造成損壞，您可能需支付最高$5000的押金</li>
        </ul>
    </div>
</template>

<style lang="scss" scoped>
.main{
    text-align: left;
    margin: 0 1.5rem;
    h2{
        font-size: 2rem;
        font-weight: 700;
    }
    h3{
        font-size: 1.5rem;
        font-weight: 700;
    }
    ul{
        li{
            margin: 2rem 0;
            display: flex;
            align-items: center;
            img{
                width: 1.3rem;
                margin-right: 1rem;
            }
        }
    }
}
@media screen and (min-width: 768px){
    .main{
        display: block !important;
        margin: 0;
        h2,h3{
            display: none;
        }
        ul{
            li{
                margin: 1rem 0;
                img{
                    width: 1.2rem;
                    margin-right: 1rem;
                }
            }
        }
    }
}
</style>