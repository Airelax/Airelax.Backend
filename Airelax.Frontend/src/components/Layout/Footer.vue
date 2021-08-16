<template>
    <footer id="footer">
        <div class="footerBox">
            <div class="row listRow">
                <div class="col-sm-12 col-md-3 AboutList" >
                    <ul class="list-group row" id="About">
                        <h4 class="list-group-item border-0"><strong>關於</strong></h4>
                    </ul>
                </div>
                <div class="col-sm-12 col-md-3 CommunityList">
                    <ul class="list-group row" id="Community">
                        <h4 class="list-group-item border-0"><strong>社區</strong></h4>
                    </ul>
                </div>
                <div class="col-sm-12 col-md-3">
                    <ul class="list-group row" id="Landlord">
                        <h4 class="list-group-item border-0 LandlordList"><strong>房東和體驗達人</strong></h4>
                    </ul>
                </div>
                <div class="col-sm-12 col-md-3">
                    <ul class="list-group row" id="Service">
                        <h4 class="list-group-item border-0 ServiseList"><strong>用戶支援</strong></h4>
                    </ul>
                </div>
            </div>
            <div class="end">
                <div class="copyright">
                    <div class="webName">&copy;xxxxxxxx,xxx.</div>
                    <div class=""><a href="">隱私</a>．<a href="">相關條款</a>．<a href="">網站地圖</a></div>
                </div>
                <div class="social col-sm-3">
                </div>
            </div>
        </div>
    </footer>

    <template id="icons">
        <a href=""><i class="fab"></i></a>
    </template>

    <template id="footerList">
        <li class="footerLi list-group-item border-0">
            <a href="" class="footerListItem"></a>
        </li>
    </template>
</template>

<script>
export default {
    mounted(){
        const aboutArray = ["使用 Airbnb 的方法", "Airbnb 新聞中心", "Airbnb 2021", "投資人", "Airbnb Plus", "Airbnb Luxe", "HotelTonight", "商務 Airbnb", "由房東和體驗達人為你實現", "工作機會", "來自創辦人的信"]
        const communityArray = ["多元化與歸屬感", "無障礙設施", "Airbnb 推廣夥伴", "防疫人員住宿", "邀請計畫", "Airbnb.org"]
        const landlordArray = ["出租房源", "舉辦線上體驗", "舉辦體驗", "房東義務", "推薦房東", "資源中心", "社區中心"]
        const serviceArray = ["我們的新冠肺炎因應措施", "說明中心", "退訂選項", "鄰里支援", "信任與安全"]
        const socialArray=["fa-facebook-f","fa-weibo","fa-twitter","fa-instagram"]

        let about = document.querySelector('#About');
        let community = document.querySelector('#Community');
        let landlord = document.querySelector('#Landlord');
        let service = document.querySelector('#Service');
        let footerList = document.querySelector('#footerList');
        let social=document.querySelector(".social");
        let iconList=document.querySelector("#icons")

        function listItem(arr,target){
            arr.forEach(function (item) {
                let cloneContent = footerList.content.cloneNode(true);
                cloneContent.querySelector('.footerListItem').innerText = item;
                target.append(cloneContent);
            });
        }
        listItem(aboutArray,about);
        listItem(communityArray,community);
        listItem(landlordArray,landlord);
        listItem(serviceArray,service);
        
        socialArray.forEach(function(item){
            let cloneContent=iconList.content.cloneNode(true);
            cloneContent.querySelector("i").classList.add(`${item}`);
            social.append(cloneContent);
        })
        
    }
}
</script>

<style lang="scss" scoped>
.row{
    --bs-gutter-x: 0 !important;
}
footer {
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    background-color: #f7f7f7;
    bottom: 0;
}
footer h4 {
    display: inline-block;
    font-size: 18px;
    padding: 0;
    text-align: left;
    margin-left: 1rem;
    font-weight: 700;
    margin-bottom: 0.5rem;
}
.footerBox .listRow {
    margin: 40px 0;
}
footer .footerBox .listRow .col-sm-12 {
    border-bottom: 1px #dddddd solid;
    padding: 2rem 0;
}
.footerBox .listRow ul {
    display: flex;
    flex-direction: row;
}
.footerBox {
    width: 90%;
    margin: auto;
}
a:hover {
    text-decoration: underline;
    color: #484848;
}
footer ul li a {
    line-height: 15px;
    color: #484848;
    text-decoration: none;
    font-size: 14px;
}
footer .list-group-item {
    background-color: #f7f7f7;
}
footer .listRow .col-md-3 .list-group .footerLi{
    display: flex;
    width: 50%;
}
.footerBox .listRow ul .footerLi .footerListItem{
    display: flex;
    white-space: nowrap;
}
footer .copyright a {
    text-decoration: none;
    color: #484848;
    font-size: 14px;
}
footer .end {
    display: flex;
    padding-bottom: 2rem;
    align-items: center;
    flex-direction: column-reverse;
    justify-content: center;
}
footer .end .copyright {
    flex-direction: column;
}
footer .end .copyright .webName {
    margin: .5rem 0;
}
footer .end .social {
    width: 50%;
    display: flex;
    align-items: center;
    justify-content: space-around;
}
footer .end .social a {
    display: flex;
    color: black;
    text-decoration: none;
}

@media screen and (min-width:768px) {
    footer .listRow {
        width: 100%;
        margin: auto;
        display: flex;
        flex-direction: row;
    }
    footer .listRow .col-md-3 {
        width: 25%;
    }
    footer .listRow .col-md-3 .list-group .footerLi .footerListItem{
        display: flex;
        flex-wrap: nowrap;
    }
    .footerBox .listRow ul {
        display: flex;
        flex-direction: column;
    }
    footer .end {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        padding-bottom: 1rem ;
    }
    footer .end .copyright {
        display: flex;
        flex-direction: row;
        align-items: center;
    }
    .webName{
        padding-right: 2rem;
    }
    footer .end .social {
        width: 25%;
        display: flex;
        flex-direction: row;
        line-height: 60px;
        justify-content: space-around;
    }
    .listRow{
        margin: 1rem 0 !important;
    }
}
</style>