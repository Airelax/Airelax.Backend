<template>
    <div class="location">
        <h2>住宿地點</h2>
        <div class="map">
            <div class="google-map">
                <iframe class="map-size" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d8933.79003527013!2d120.9489181880148!3d24.760822431644378!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x34684a5cb60622fd%3A0xb0ead5088c97b0db!2z5Lit6I-v5aSn5a24!5e0!3m2!1szh-TW!2stw!4v1625237363150!5m2!1szh-TW!2stw" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
            </div>
            <p>預訂確認後會提供確切位置。</p>
        </div>
        <span>{{detail.Town}}、{{detail.City}}、{{detail.country}}</span>
    </div>
</template>

<script>
export default {
    props:["detail"]
}
</script>

<style lang="scss" scoped>
.location{
    text-align: left;
    padding-bottom: 1.5rem;
    margin-top: 1.5rem;
    border-bottom: 1px solid rgb(209, 206, 206);
    h2{
        font-size: 1.5rem;
        font-weight: 900;
    }
    .map{
        margin: 1.5rem 0;
        border: 1px solid rgb(209, 206, 206);
        border-radius: 18px;
        overflow: hidden;
        p{
            margin: 1rem;
            color: #717171;
            font-size: 0.8rem;
        }
        .map-size{
            width: 100%;
            height: 15rem;
        }
    }
    span{
        font-weight: 900;
        color: #222222;
    }
}
@media screen and (min-width:768px){
    .location{
        .map{
            position: relative;
            .map-size{
                height: 30rem;
            }
            p{
                display: block;
                position: absolute;
                left: 0;
                bottom: 10%;
                right: 0;
                margin: auto;
                padding: 1rem;
                background-color: #ffffff;
                width: 20rem;
                font-size: 1.1rem;
                font-weight: 700;
                text-align: center;
                border-radius: 8px;
            }
        }
    }
}
</style>