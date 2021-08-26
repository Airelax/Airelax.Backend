<template>
    <div class="List-pill rounded-pill" @click="show">
        <div class="ham"></div>
            <i class="fas fa-user-circle"></i>
            <ul class="list-group">
                <li class="list-group-item border-0 rounded-top">
                    <a href="#">
                        <strong>訊息</strong>
                    </a>
                </li>
                <li class="list-group-item border-0">
                    <a href="#">
                        <strong>通知</strong>
                    </a>
                </li>
                <li class="list-group-item border-0">
                    <a href="#">
                        <strong>旅程</strong>
                    </a>
                </li>
                <li class="list-group-item border-0 border-bottom">
                    <a href="#">
                        <strong>心願單</strong>
                    </a>
                </li>
                <li class="list-group-item border-0">
                    <a href="#">
                        <strong>管理房源</strong>
                    </a>
                </li>
                <li class="list-group-item border-0">
                    <a href="#">
                        <strong>舉辦體驗</strong>
                    </a>
                </li>
                <li class="list-group-item border-0 border-bottom">
                    <a href="#">
                        <strong>帳號</strong>
                    </a>
                </li>
                <li class="list-group-item border-0">
                    <a href="#">
                        <strong>協助</strong>
                    </a>
                </li>
                <li class="list-group-item border-0 rounded-end">
                    <a href="#">
                        <strong>登出</strong>
                    </a>
                </li>
            </ul>
        </div>
</template>

<script>
export default {
    methods:{
        show(){
            let banner = document.getElementById('banner');
            let listGroup = document.querySelector('.list-group');
            listGroup.style.display = 'block';
            banner.style.display = 'block';
            banner.addEventListener('click',(e)=>{
                listGroup.style.display = 'none';
                e.target.style.display = 'none';
            })
        }
    },
    mounted(){
        let listGroup = document.querySelector('.list-group');
        window.addEventListener("scroll", function() {
            listGroup.style.display = 'none';
        });
	}
}
</script>

<style lang="scss" scoped>
.List-pill{
    background-color: #ffffff;
    width: 77px;
    height: 42px;
    display: flex;
    flex-direction: row;
    align-items: center;
    position: relative;
    cursor: pointer;
    border-radius: 18px;
    border: 1px solid rgb(184, 184, 184);
}
.list-group{
    position: absolute;
    top: 53px;
    right: 0;
    width: 225px;
    display: none;
    z-index: 10;
    border-radius: 18px;
    overflow: hidden;
    border: 1px solid rgb(184, 184, 184);
}
.ham {
    display: block;
    content: '';
    height: 2px;
    width: 15px;
    background-color: #222222;
    margin: auto;
    box-shadow: 0px 4px 0px #222222,
        0px -4px 0px #222222;
}
.list-group-item{
    padding: 15px;
}
.list-group li a{
    text-decoration: none;
    color: black;
}
.list-group li:hover{
    background-color: #E7F0EB;
}
.list-group li{
    font-size: .5rem;
    line-height:18px;
}
i{
    width: 2rem;
    font-size: 1.5rem;
    text-align: left;
}
strong{
    font-weight: 400;
    font-size: 1rem;
}
</style>