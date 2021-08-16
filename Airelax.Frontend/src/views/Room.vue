<template>
    <div v-if="get" class="top">
        <Share v-if="fullWidth < 768"></Share>
        <Picture :pic="data.pictures" v-if="fullWidth < 768" data-bs-toggle="modal" data-bs-target="#myModal" @click="isPicShow = true"></Picture>
        <div class="gap">
            <div class="mix-detail">
                <h1>{{data.title}}</h1>
                <div class="mix-md d-flex">
                    <div class="remix">
                        <i class="fas fa-star"></i>
                        <span class="num">{{data.rank.star}}</span>
                        <a href="#">({{data.comments.length}}則評論)</a>
                        <span class="dot">·</span>
                        <a href="#"><span>{{data.Location.Town}}、{{data.Location.City}}、{{data.Location.country}}</span></a>
                    </div>
                    <Share v-if="fullWidth > 768"></Share>
                </div>
            </div>
            <Picture :pic="data.pictures" v-if="fullWidth > 768"></Picture>
                <div class="row sticky-section">
                    <div class="col-12 col-md-7">
                        <div class="landlord-brief">
                            <div class="house">
                                <div class="txt">
                                    <h2 v-if="fullWidth > 768">{{data.Owner.name}}出租的整套出租住所</h2>
                                    <div v-if="fullWidth < 768">
                                        <p>整套出租住所</p>
                                        <p>房東 : {{data.Owner.name}}</p>
                                    </div>
                                </div>
                                <a class="img">
                                    <img src="https://picsum.photos/50/50/?random=1">
                                </a>
                            </div>
                            <div class="detail">
                                <span>{{data.Space.CustomerNumber}}位 · {{data.Space.Bedroom}}間臥室 · {{data.Space.Bed}}張床 · {{data.Space.Bathroom}}間衛浴</span>
                            </div>
                        </div>
                        <div class="honor">
                           <ul>
                               <li v-for="item in data.Honor" :key="item.type">
                                   <i class="fas fa-home"></i>
                                   <div class="detail">
                                       <p>type:{{item.type}} 整套房源</p>
                                       <span>{{item.description}}</span>
                                   </div>
                               </li>
                           </ul>
                        </div>
        
                        <div class="description">
                           <p>{{data.Description.HouseDescription}}</p>
                           <a data-bs-toggle="modal" data-bs-target="#myModal" @click="isDescShow = true">顯示更多內容 ></a>
                        </div>
                        
                        <Bed></Bed>
                        
                        <div class="facility">
                           <h2>有提供的設備與服務</h2>
                           <ul>
                             <div class="row">
                                <div class="col-12 col-md-6">
                                    <li v-for="item in data.facility.provide" :key="item">
                                        <i class="fas fa-tv"></i> <span> {{item}} 電視</span>
                                    </li>
                                </div>
                             </div>
                           </ul>
                           <a data-bs-toggle="modal" data-bs-target="#myModal" @click="isFacilityShow = true">顯示全部{{data.facility.provide.length}}項設備與服務</a>
                        </div>  
                        <Location :detail="data.Location" v-if="fullWidth < 768"></Location>
                        <div class="dateBottom">
                            <keep-alive>
                                <Date></Date>
                            </keep-alive>
                        </div>
                    </div>
                    <div class="col-12 col-md-5 price-sticky">
                        <div class="price">
                           <div class="mix">
                               <p>${{data.Price.origin.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',')}} / 晚</p>
                               <div>
                                   <i class="fas fa-star"></i>
                                   <span class="num">{{data.rank.star}}</span>
                                   <a href="#">({{data.comments.length}}則評論)</a>
                               </div>
                           </div>

                            <keep-alive>
                                <DatePicker v-if="fullWidth > 768"></DatePicker>
                            </keep-alive>

                            <button v-if="Object.keys($store.state.date).length === 0" data-bs-toggle="modal" data-bs-target="#myModal" @click="isDateShow = true">查看可訂日期</button>
                            <button v-else>預定</button>

                            <div class="hide-price" v-if="fullWidth > 768 && Object.keys($store.state.date).length !== 0">
                                <div class="price-show"><p>${{data.Price.origin.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',')}} X N晚</p><span>${{data.Price.origin.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',')}}</span></div>
                                <div class="price-show"><p>服務費</p><span>$0</span></div>
                                <div class="price-show"><p>住宿稅和費用</p><span>$0</span></div>
                                <div class="price-total"><p>總價</p><span>${{data.Price.origin.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ',')}}</span></div>
                            </div>

                        </div>
                    </div>
                </div>
            
                   <!-- sticky -->
        
            <Comment @Show="CommentShow"></Comment>

            <Location :detail="data.Location" v-if="fullWidth > 768"></Location>

            <div class="row landlord-section">
                <div class="col-12 col-md-6">
                    <div class="landlord">
                       <div class="detail">
                           <div class="txt">
                               <p>房東 : {{data.Owner.name}}</p>
                               <span>加入時間 : {{data.Owner.registerTime}}</span>
                           </div>
                           <a class="img">
                               <img src="https://picsum.photos/50/50/?random=1">
                           </a>
                       </div>
                       <div class="mix">
                           <p><i class="fas fa-star"></i> {{data.comments.length}}則評論</p>
                           <p><i class="fas fa-user-shield"></i>身分已驗證</p>
                       </div>
                       <div class="brief">
                           <p>{{data.Owner.name}}是超讚房東</p>
                           <span>超讚房東是一批經驗豐富、深獲房客好評的房東，全心為房客提供超棒的入住體驗。</span>
                       </div>
                       <a class="contact" data-bs-toggle="modal" data-bs-target="#myModal" @click="isConnectShow = true">聯絡房東</a>
                       <div class="security">
                           <span>為了確保您的付款安全，切勿透過Airbnb網站或應用程式以外的方式進行匯款或聯絡。</span>
                           <div class="icon"><img src="../assets/image/Room/icon/security.svg"></div>
                       </div>
                    </div>
                </div>
            </div>
            
            <div class="rule">
               <h2 v-if="fullWidth > 768">注意事項</h2>
               <div class="rule-section">
                   <a data-bs-toggle="modal" data-bs-target="#myModal" @click="isRuleShow = true" class="regulation main">
                       <div class="txt">
                           <h2>《房屋守則》</h2>
                           <span>入住時間 : 下午{{data.HouseRule.checkinTime.split('-')[0]}}</span>
                           <HouseRule v-if="fullWidth > 768" :detail="data.HouseRule"></HouseRule>
                       </div>
                       <div class="arrow">></div>
                   </a>
                   <a data-bs-toggle="modal" data-bs-target="#myModal" @click="isHealthyShow = true" class="healthy main">
                       <div class="txt">
                           <h2>健康與安全</h2>
                           <span>運用Airbnb社交距離指南和其他防疫指南</span>
                           <Healthy v-if="fullWidth > 768" :detail="data.HouseRule"></Healthy>
                       </div>
                       <div class="arrow">></div>
                   </a>
                   <a data-bs-toggle="modal" data-bs-target="#myModal" @click="isDatePickerShow = true" class="regulation main">
                       <div class="txt">
                           <h2>退訂政策</h2>
                           <span>新增旅程日期，即可查看此住宿的退訂詳情。</span>
                           <Cancel v-if="fullWidth > 768 && Object.keys($store.state.date).length !== 0"></Cancel>
                       </div>
                       <div class="arrow">></div>
                   </a>
               </div>
            </div>
            <div class="modal fade" tabindex="-1" id="myModal" data-bs-backdrop="static" data-bs-keyboard="false">
                <div class="modal-dialog modal-lg modal-dialog-scrollable modal-dialog-centered modal-fullscreen-md-down">
                    <div class="modal-content">
                        <button type="button" class="btn" data-bs-dismiss="modal" aria-label="Close" @click="invisible">
                            <img src="../assets/image/Room/icon/back.svg">
                        </button>
                    <div class="modal-body">
                        <Description v-if="isDescShow" :detail="data.Description"></Description>
                        <Facility v-if="isFacilityShow" :detail="data.facility"></Facility>
                        <Connect v-if="isConnectShow" :detail="data.Owner" :rule="data.HouseRule"></Connect>
                        <HouseRule v-if="isRuleShow" :detail="data.HouseRule"></HouseRule>
                        <Healthy v-if="isHealthyShow" :detail="data.HouseRule"></Healthy>
                        <keep-alive>
                            <Date v-if="isDateShow"></Date>
                        </keep-alive>
                        <People v-if="isPeopleShow"></People>
                        <AllPicture v-if="isPicShow && fullWidth < 768" :detail="data.pictures"></AllPicture>
                        <keep-alive>
                            <DatePicker v-if="isDatePickerShow && Object.keys($store.state.date).length === 0"></DatePicker>
                        </keep-alive>
                        <Cancel v-if="isDatePickerShow && Object.keys($store.state.date).length !== 0"></Cancel>
                        <CommentModal v-if="isCommentShow"></CommentModal>
                    </div>
                    <div class="modal-footer d-flex flex-row justify-content-between" v-if="isConnectShow">
                        <p>有其他疑問嗎？</p>
                        <button type="button" class="btn btn-primary btn-dark">傳訊息給房東</button>
                    </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
import axios from 'axios';
import Picture from '../components/Room/Picture';
import Share from '../components/Room/Share';
import Description from '../components/Room/Decsription';
import Facility from '../components/Room/Facility';
import Date from '../components/Room/Date';
import Connect from '../components/Room/Connect';
import HouseRule from '../components/Room/HouseRule';
import Healthy from '../components/Room/Healthy';
import Location from '../components/Room/Location';
import People from '../components/Room/People';
import AllPicture from '../components/Room/AllPicture';
import DatePicker from '../components/Room/DatePicker';
import Cancel from '../components/Room/Cancel';
import Comment from '../components/Room/Comment';
import CommentModal from '../components/Room/ModalComment';
import Bed from "../components/Room/RoomDatasWithPic";

export default {
  data(){
    return{
        data: {},
        get: false,
        isDescShow: false,
        isFacilityShow: false,
        isConnectShow: false,
        isRuleShow: false,
        isHealthyShow: false,
        isDateShow: false,
        isPeopleShow: false,
        isPicShow: false,
        isDatePickerShow: false,
        isCommentShow: false,
        fullWidth: 0,
    }
  },
  methods:{
      getList() {
        const api = 'https://bs-howard.github.io/Homework/fake-room-data.json';
        axios.get(api)
        .then(response => {
            this.data = response.data;
            this.get = true
        })
        .catch( error => {
            console.log(error);
        })
      },
      invisible() {
          this.isDescShow = false;
          this.isFacilityShow = false;
          this.isConnectShow = false;
          this.isRuleShow = false;
          this.isHealthyShow = false;
          this.isDateShow = false;
          this.isPeopleShow = false;
          this.isPicShow = false;
          this.isDatePickerShow = false;
          this.isCommentShow = false;
      },
      CommentShow(val){
          this.isCommentShow = val;
      }
  },
  watch:{
      fullWidth(val){
          this.fullWidth = val;
      }
  },
  mounted() {
      this.getList();
      const vm = this;
      this.fullWidth = document.body.clientWidth;
      window.addEventListener("resize", function() {
        vm.fullWidth = document.body.clientWidth;
      });
  },
  components:{
      Picture,
      Share,
      Description,
      Facility,
      Date,
      Connect,
      HouseRule,
      Healthy,
      Location,
      People,
      AllPicture,
      DatePicker,
      Cancel,
      Comment,
      CommentModal,
      Bed
  }
}
</script>

<style lang="scss" scoped>
@import '../assets/css/reset.css';
.top{
    position: relative;
    text-align: left;
    color: #000;
    a{
        cursor: pointer;
    }
    .gap{
        margin: 0 1.5rem;
    }
    .mix-detail{
        border-bottom: 1px solid rgb(209, 206, 206);
        h1{
            font-size: 1.5rem;
            font-weight: 700;
            margin: 1rem 0;
            line-height: 2rem;
        }
        .remix{
            font-size: .9rem;
            font-weight: 700;
            padding-bottom: 1.5rem;
            
            i{
                color: #FF385C;
            }
            .num{
                margin: 0 .2rem;
                color: #222222;
            }
            .dot{
                margin: 0 .5rem;
            }
            a{
                color: #717171;
            }
        }
    }
    .landlord-brief{
        border-bottom: 1px solid rgb(209, 206, 206);
        .house{
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin: 1rem 0;
            .txt{
                font-weight: 700;
                p{
                    margin: 0.6rem 0;
                }
                h2{
                    font-size: 1.5rem;
                    font-weight: 700;
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
        .detail{
            padding-bottom: 1.5rem;
        }
    }
    .honor{
        border-bottom: 1px solid rgb(209, 206, 206);
        li{
            display: flex;
            margin: 2rem 0;
            align-items: center;
            i{
                font-size: 1.5rem;
                align-self: start;
            }
            .detail{
                
                margin-left: 1rem;
                p{
                    margin-bottom: .5rem;
                    font-size: 1.1rem;
                    font-weight: 700;
                }
                span{
                    color: #717171;
                    font-size: 0.9rem;
                }
            }
        }
    }
    .description{
        padding: 1rem 0;
        border-bottom: 1px solid rgb(209, 206, 206);
        a{
            text-decoration: underline;
            display: block;
            margin: 1rem 0;
            font-weight: 900;
            color: #222222;
            &:hover{
                color: #000;
            }
        }
    }
    .facility{
        padding: 1.5rem 0;
        border-bottom: 1px solid rgb(209, 206, 206);
        h2{
            font-size: 1.5rem;
            font-weight: 900;
        }
        li{
            margin: 2rem 0;
            span{
                margin-left: .7rem;
            }
        }
        a{
            display: block;
            text-decoration: none;
            padding: 1rem 2rem;
            color: #222222;
            text-align: center;
            border: 1px solid #222222;
            border-radius: 8px;
            font-weight: 700;
            transition: .3s;
            &:hover{
                background-color: #ddd9d9;
            }
        }
    }
    .price{
        position: fixed;
        left: 0;
        bottom: 0;
        background-color: #ffffff;
        display: flex;
        justify-content: space-between;
        border-top: 1px solid rgb(231, 231, 231);
        width: 100%;
        padding: .8rem 1.5rem;
        z-index: 100;
        .mix{
            i {
                color: #FF385C;
            }
            a{
            color: #717171;
            }
            p{
                font-size: 1.2rem;
                font-weight: 700;
                margin: 0.5rem 0;
            }
        }
        button{
            background-color: rgb(215, 4, 102);
            color: #fff;
            font-weight: 700;
            padding: 0 1.8rem;
            border: none;
            border-radius: 8px;
            &:hover{
                background-color: rgb(197, 4, 94);
            }
        }
        .hide-price{
            .price-show{
                display: flex;
                justify-content: space-between;
                margin: 1rem 0;
            }
            .price-total{
                display: flex;
                justify-content: space-between;
                padding: 1rem 0;
                border-top: 1px solid #717171;
                font-weight: 700;
                font-size: 1.2rem;
            }
        }
    }
    .landlord{
        margin-top: 1.5rem;
        border-bottom: 1px solid rgb(209, 206, 206);
        .detail{
            display: flex;
            justify-content: space-between;
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
        .mix{
            margin: 2rem 0;
            p{
                margin: 1.3rem 0;
                color: #222222;
                i{
                    color: #FF385C;
                    margin-right: 1rem;
                }
            }
        }
        .brief{
            p{
                font-weight: 700;
                font-size: 1.2rem;
            }
            span{
                display: block;
                margin: 1rem 0;
                line-height: 1.6rem;
            }
        }
        .contact{
            display: block;
            text-decoration: none;
            padding: 1rem 2rem;
            color: #222222;
            text-align: center;
            border: 1px solid #222222;
            border-radius: 8px;
            font-weight: 700;
            transition: .3s;
            &:hover{
                background-color: #ddd9d9;
            }
        }
        .security{
            display: flex;
            margin: 1rem 0;
            align-items: center;
            span{
                font-size: 0.8rem;
                line-height: 1.2rem;
            }
            .icon{
                padding: .5rem;
                img{
                width: 1.5rem;
                }
            }
        }
    }
    .rule{
        h2{
            font-size: 1.5rem;
            font-weight: 700;
        }
        .main{
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin: 1.5rem 0;
            border-bottom: 1px solid rgb(209, 206, 206);
            text-decoration: none;
            color: #222222;
            .txt{
                h2{
                    font-size: 1.5rem;
                    font-weight: 900;
                }
                span{
                    display: block;
                    color: #717171;
                    margin: 1rem 0;
                    font-size: 0.9rem;
                }
            }
            .arrow{
                font-size: 1.5rem;
            }
        }
        .report{
            a{
                margin-left: 1rem;
                color: #222222;
            }
        }
    }
    .modal{
        .btn{
            width: 10%;
            padding: 1rem 2rem;
            img{
                width: 1.3rem;
            }
        }
        .modal-footer{
            button{
                width: 50%;
                font-weight: 700;
                border-radius: 8px;
                font-size: 1.1rem;
            }
        }
    }
}
.dateBottom{
    border-bottom: 1px solid rgb(209, 206, 206);
}
.price-sticky{
    position: relative;
}
.nav{
    width: 100vw;
    height: 5rem;
    background-color: #fff;
    border: 1px solid #000;
    position: fixed;
    z-index: 100;
    top: 0;
    left: 0;
    opacity: 0;
}
.nav.show{
    opacity: 100;
}

@media screen and (min-width:768px){
    .top{
        margin: 0 11rem;
        padding-top: 7rem;
        .bed,.comments,.footer
        {
            .txt{
                height: 20rem;
                line-height: 20rem;
            }
        }
        .landlord-section,
        .sticky-section{
            position: relative;
            border-bottom: 1px solid rgb(209, 206, 206);
            margin: 0 .1rem;
        }
        .mix-detail{
            border: none;
            .mix-md{
                justify-content: space-between;
                height: 3.5rem;
            }
        }
        .landlord-brief{
            .detail{
                margin-top: -1rem;
            }
        }
        .facility{
            a{
                width: 38%;
            }
        }
        .landlord{
            border: none;
        }
        .rule{
            margin-top: 1.5em;
            .rule-section{
                display: flex;
                justify-content: space-between;
                align-items: flex-start;
                .main{
                    width: 20rem;
                    border: none;
                    pointer-events: none;
                    .txt{
                        h2{
                            font-size: 1rem;
                        }
                    }
                    .arrow,
                    span{
                        display: none;
                    }
                }
            }
        }
        .price{
            position: sticky;
            bottom: unset;
            top: 10rem;
            z-index: 5;
            border: 1px solid #cacaca;
            box-shadow: 3px 3px 10px rgb(179, 179, 179);
            border-radius: 18px;
            flex-direction: column;
            width: 90%;
            margin: auto;
            margin-top: 2rem;
            .mix{
                display: flex;
                justify-content: space-between;
                align-items: center;
                p{
                    font-size: 1.5rem;
                }
            }
            button{
                height: 3rem;
                margin-bottom: .8rem;
                
            }
            .choice{
                border: 1px solid #717171;
                border-radius: 8px;
                margin: 1rem 0;
                cursor: pointer;
                .pick-date{
                    display: flex;
                    justify-content: space-between;
                    border-bottom: 1px solid #717171;
                    .in-date{
                        border-right: 1px solid #717171;
                    }
                }
                .search-div {
                    width: 50%;
                    padding: .5rem 0;
                    margin-left: 0.5rem;
                    span{
                        font-weight: 700;
                    }
                    .placeholder{
                        color: #717171;
                        margin: 0.1rem 0;
                    }
                }
                .people{
                    width: 100%;
                }
            }
        }
    }
    .dateBottom{
        border-bottom: none;
    }
}
</style>
