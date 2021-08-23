<template>
    <header>
        <form action="#">
          <div class="searchBar">
            <div class="search-div search-position" @click="HideBody">
              <i class="fas fa-search sm-search-icon"></i>
              <label>
                <span class="search-title sm-search-title">位置</span>
                <input id="searchInput" type="text" placeholder="你想去哪裡 ?" autocomplete="off" v-model="$store.state.destination"/>
              </label>
            </div>
            <div class="lg-search">
                <v-date-picker :transition="'none'" :columns="$screens({ default: 2})" color="pink" :model-config="modelConfig" is-range v-model="$store.state.date">
                <template v-slot="{ inputValue, inputEvents }">
                  <div class="picker">
                    <div  id="in-date-time" class="search-div in-date">
                        <span class="search-title">入住</span>
                        <input
                          placeholder="新增日期"
                          :value="inputValue.start"
                          v-on="inputEvents.start"
                          class="px-2 py-1 focus:outline-none focus:border-indigo-300"
                          readonly
                        />
                    </div>
                    <div id="out-date-time" class="search-div out-date">
                        <span class="search-title">退房</span>
                        <input
                        placeholder="新增日期"
                          :value="inputValue.end"
                          v-on="inputEvents.end"
                          class="px-2 py-1 rounded focus:outline-none focus:border-indigo-300"
                          readonly
                        />
                    </div>
                  </div>
                </template>
                </v-date-picker>
              <div class="search-div search-people">
                  <div>
                    <span class="search-title">人數</span>
                    <div class="placeholder" v-if="adult===0">新增人數</div>
                    <div class="placeholder" v-else>{{adult+child}}位,{{toddler}}名嬰幼兒</div>
                  </div>
                  <div class="lg-search-icon">
                    <i class="fas fa-search"></i>
                    <span class="lg-search-icon-txt">搜尋</span>
                  </div>
              </div>
            </div>
          </div>
          <button class="sm-cancel" @click="TurnBack">取消</button>
        </form>
      <div class="location">
        <ul>
          <li>
            <ul>
              <li><span>隨時隨地出發</span></li>
              <li>
                <a href="#">
                  <div class="everywhere">
                    <p>隨心所欲</p>
                    <i class="fas fa-home"></i>
                  </div>
                </a>
              </li>
            </ul>
          </li>
          <li>
            <ul class="record">
              <li><span>近期搜尋紀錄</span></li>
              <li class="place">
                <a href="#">
                  <div class="clock"><i class="far fa-clock"></i></div>
                  <div class="searchPlace">近期搜尋地點</div>
                </a>
              </li>
            </ul>
          </li>
        </ul>
      </div>
      <div class="people">
        <div class="people-control">
          <div class="txt">
            <strong>成人</strong>
            <span>滿13歲</span>
          </div>
          <div>
            <button class="minus" @click="minus" id="adult-minus">-</button><span id="adult">{{adult}}</span
            ><button class="plus" @click="plus" id="adult-plus">+</button>
          </div>
        </div>
        <div class="people-control" id="child">
          <div class="txt">
            <strong>兒童</strong>
            <span>2 - 12歲</span>
          </div>
          <div>
            <button class="minus" @click="minus" id="child-minus">-</button><span>{{child}}</span
            ><button class="plus" @click="plus" id="child-plus">+</button>
          </div>
        </div>
        <div class="people-control" id="toddler">
          <div class="txt">
            <strong>嬰幼兒</strong>
            <span>2歲以下</span>
          </div>
          <div>
            <button class="minus" @click="minus" id="toddler-minus">-</button><span>{{toddler}}</span
            ><button class="plus" @click="plus" id="toddler-plus">+</button>
          </div>
        </div>
    </div>
    </header>
     
</template>

<script>
export default {
    data(){
        return{
            modelConfig: {
                type: 'string',
                mask: 'YYYY年MM月DD日'
            },
        }
    },
    methods:{
        HideBody(){
          if(this.$store.state.fullWidth<768)
            this.$store.state.isBodyShow = false;
        },
        TurnBack(e){
          this.$store.state.isBodyShow = true;
          document.querySelector('.location').classList.remove('rwdShow');
          document.querySelector('.searchBar').classList.remove('toggle');
          document.querySelector('.searchBar').parentElement.style.backgroundColor = 'transparent';
          document.getElementById('footer').style.display = 'flex';
          e.target.style.display = 'none';
        },
        plus(e){
          if(e.target.getAttribute('id')=='adult-plus') this.$store.state.adult+=1;
          else if(e.target.getAttribute('id')=='child-plus') this.$store.state.child+=1;
          else if(e.target.getAttribute('id')=='toddler-plus') this.$store.state.toddler+=1;
        },
        minus(e){
          if(e.target.getAttribute('id')=='adult-minus') this.$store.state.adult-=1;
          else if(e.target.getAttribute('id')=='child-minus') this.$store.state.child-=1;
          else if(e.target.getAttribute('id')=='toddler-minus') this.$store.state.toddler-=1;
        }
    },
    computed:{
      adult(){
        return this.$store.state.adult
      },
      child(){
        return this.$store.state.child
      },
      toddler(){
        return this.$store.state.toddler
      }
    },
    watch:{
      adult(val){
        if(val<=0){
          this.$store.state.adult = 0;
          this.$store.state.child = 0;
          this.$store.state.toddler = 0;
        }
      },
      child(val){
        if(val<0 || this.$store.state.adult===0) this.$store.state.child = 0
      },
      toddler(val){
        if(val<0 || this.$store.state.adult===0) this.$store.state.toddler = 0
      }
    },
    mounted(){
        const vm = this;

        let searchBar = document.querySelector('.searchBar');
        let lgSearchBtn = document.querySelector('.lg-search-icon');
        let lgSearchTxt = document.querySelector('.lg-search-icon-txt');
        let searchPosition = document.querySelector('.search-position');
        let locationPart = document.querySelector('.location');
        let searchPeople = document.querySelector('.search-people');
        let peoplePart = document.querySelector('.people');
        let footer = document.getElementById('footer');
        const cancelBtn = document.querySelector('.sm-cancel');
        const rwdWidth = 768;

        //下滑fixed
        window.addEventListener("scroll", function() {
            let top = document.documentElement.scrollTop;
            banner.style.display = 'none'
            locationPart.classList.add('toggle');
            peoplePart.classList.add('toggle');
            lgSearchBtn.classList.remove('toggle');
            lgSearchTxt.style.display = 'none';
            if(top>1 && vm.$store.state.fullWidth<768){
              searchBar.classList.add('fixed');
            }
            else{
              searchBar.classList.remove('fixed');
            }
        });

        // 搜尋按下去的畫面
        searchPosition.addEventListener('click', () => {
        // 手機板
        if (document.body.clientWidth < rwdWidth) {
            locationPart.style.marginLeft = 'unset';
            locationPart.classList.remove('show','toggle');
            locationPart.classList.add('rwdShow');
            searchBar.classList.add('toggle');
            searchBar.parentElement.style.backgroundColor = '#fff';
            searchPosition.style.backgroundColor = 'transparent';
            cancelBtn.style.display = 'block';
            footer.style.display = 'none'
        }
        // 電腦版
        else {
            peoplePart.classList.remove('show');
            locationPart.classList.remove('toggle');
            locationPart.classList.add('show');
            locationPart.style.marginLeft = `${searchBar.offsetLeft}px`;
        }
        });

        searchPeople.addEventListener('click', (e) => {
        if(locationPart.style.display === '')
            locationPart.classList.add('toggle');

        peoplePart.classList.remove('toggle');
        peoplePart.classList.add('show');
        peoplePart.style.marginLeft = `${searchBar.offsetLeft + searchBar.offsetWidth - peoplePart.offsetWidth}px`;
        focus(e.target);
        });

        let banner = document.getElementById('banner');
        // 電腦版搜尋按下去會跑出'搜尋'
        searchBar.addEventListener('click', () => {
        // 鎖定
        if (document.body.clientWidth > rwdWidth) {
            lgSearchBtn.classList.add('toggle');
            lgSearchTxt.style.display = 'block';
            banner.style.display = 'block';
            banner.addEventListener('click', (e) => {
            // 復原
            e.target.style.display = 'none';
            locationPart.classList.add('toggle');
            peoplePart.classList.add('toggle');
            lgSearchBtn.classList.remove('toggle');
            lgSearchTxt.style.display = 'none';
            });
        }
        });
    }
}
</script>

<style lang="scss" scoped>
* {
  margin: 0;
  padding: 0;
  list-style: none;
  text-align: left;
}
header {
  width: 100%;
  form {
    position: relative;
    display: flex;
    justify-content: space-evenly;
    padding-top: 1rem;
    margin-bottom: -1px;
    .searchBar {
      position: relative;
      z-index: 10;
      display: flex;
      width: 88%;
      max-width: 900px;
      margin: auto 0;
      padding: 0.9rem 1.5rem;
      background-color: #fff;
      border-radius: 28px;
      align-items: center;
      &.fixed{
        position: fixed;
        transition: .3s;
        top: 1.8%;
        border: 2px solid rgb(121, 121, 121);
        box-shadow: 5px 5px 10px rgb(160, 160, 160);
      }
      &.toggle {
        background-color: #f1f1f1;
        width: 80%;
      }
      .search-position {
        width: 100%;
        display: flex;
        align-items: center;
        .sm-search-icon {
          cursor: pointer;
        }
        label {
          flex-grow: 1;
          input {
            border: none;
            width: 95%;
            font-size: 1.1rem;
            margin-left: 1rem;
            background-color: transparent;
            outline: none;
          }
        }
      }
      .lg-search {
        display: none;
        align-items: center;
        width: 100%;
        
        .search-people {
          display: flex;
          justify-content: space-between;
          align-items: center;
          height: 4rem;
          .lg-search-icon {
            display: flex;
            align-items: center;
            width: 3rem;
            height: 3rem;
            margin-right: 1rem;
            background-color: #ff385c;
            color: #fff;
            border-radius: 50%;
            &.toggle{
              width: 6rem;
              border-radius: 28px;
            }
            &:hover {
              background-color: #ce1739;
            }
            i {
              margin: auto;
            }
            .lg-search-icon-txt {
              display: none;
              font-weight: 900;
              margin-right: 1rem;
            }
          }
        }
      }
      .search-title {
        margin-left: 1rem;
        font-weight: 700;
        pointer-events: none;
      }
      .sm-search-title {
        display: none;
      }
    }
    .sm-cancel {
      background-color: #fff;
      border: none;
      width: 3rem;
      font-weight: 900;
      display: none;
    }
  }
  .location {
    position: relative;
    z-index: 10;
    display: none;
    width: 100%;
    height: 100vh;
    background-color: #fff;
    position: relative;
    &.rwdShow{
      width:100%;
      display: flex;
      border-radius: unset;
      height: 100vh;
    }
    &.show{
      width:25rem;
      display: block;
      border-radius: 28px;
      height: 40vh;
    }
    &.show.toggle{
      display: none;
    }
    ul {
      width: 100%;
      padding-left: 0;
      padding: 0.5rem 1rem;
      li:first-child {
        span {
          font-size: 0.8rem;
          font-weight: 700;
        }
      }
      a {
        text-decoration: none;
        .everywhere {
          display: flex;
          justify-content: left;
          align-items: center;
          width: 100%;
          margin: 1rem auto;
          height: 3.5rem;
          padding: 0.9rem 1.5rem;
          background-color: #fff;
          border-radius: 28px;
          border: 1px solid rgb(202, 202, 202);
          box-shadow: 5px 5px 10px 5px rgb(214, 212, 212);
          color: rgb(167, 19, 167);
          p {
            font-size: 1.2rem;
            font-weight: 900;
            margin: auto;
            margin-left: 0;
          }
          i {
            font-size: 1.8rem;
          }
        }
      }
      .record {
        .place {
          display: flex;
          margin: 1rem 0;
          a {
            text-decoration: none;
            color: #000;
            display: flex;
            .clock {
              display: flex;
              width: 3rem;
              height: 3rem;
              background-color: #f1f1f1;
              border-radius: 6px;
              i {
                margin: auto;
              }
            }
            .searchPlace {
              margin: auto;
              margin-left: 1rem;
            }
          }
        }
      }
    }
  }
  .people {
    position: relative;
    z-index: 10;
    background-color: #fff;
    border-radius: 28px;
    display: none;
    flex-direction: column;
    margin-top: 1rem;
    &.show{
      display: flex;
    }
    &.show.toggle{
      display: none;
    }
    .people-control {
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding: 1.2rem 0;
      &:not(:last-child) {
        border-bottom: 1px solid rgb(204, 201, 201);
      }
      margin: 0.3rem 2rem;
      .txt {
        display: flex;
        flex-direction: column;
        line-height: 1.2rem;
        strong {
          font-size: 1.2rem;
        }
        span {
          color: rgb(104, 102, 102);
          font-size: 0.9rem;
        }
      }
      button {
        width: 2rem;
        height: 2rem;
        margin: 0 0.8rem;
        border-radius: 50%;
        background-color: #fff;
        border: 1px solid rgb(204, 201, 201);
        font-size: 1.2rem;
        text-align: center;
      }
    }
  }
}

@media screen and (min-width: 768px) {
  header{
    form{
      padding-top: 6rem;
      .searchBar {
        padding: 0rem;
        border-radius: 50px;
        border: 1px solid rgb(196, 196, 196);
        .search-position {
          width: 50%;
          .sm-search-icon {
            display: none;
          }
          .sm-search-title {
            display: inline;
          }
          #searchInput{
            margin-top: 0.2rem;
            font-size: 0.9rem;
            margin-left: 1rem;
          }
        }
        .lg-search {
          display: flex;
          flex-grow: 1;
          .search-div {
            flex-grow: 1;
          }
          .picker{
            display: flex;
            align-items: center;
            width: 30%;
            input{
              display: block;
              border: none;
              outline: none;
              margin-left: 0.5rem;
              cursor: pointer !important;
              width: 10rem;
              background-color: transparent;
              font-size: 0.9rem;
            }
            .search-div{
              padding-top: .9rem;
            }
          }
        }
        .search-div {
          border-radius: 50px;
          cursor: pointer;
          padding: .6rem 0;
          height: 4rem;
          label {
            cursor: pointer;
          }
          &:hover {
            background-color: rgb(228, 228, 228) !important;
          }
          &:first-child {
            padding-left: 1rem;
          }
          border-right: 1px solid rgb(199, 198, 198);
          .placeholder {
            margin-left: 1.1rem;
            color: rgb(97, 96, 96);
            font-size: 0.9rem;
            margin-top: 0.3rem;
          }
        }
      }
    }
    .people{
      width: 25rem;
      border: 1px solid rgb(202, 202, 202);
    }
    .location{
      margin-top: 1rem;
      border: 1px solid rgb(202, 202, 202);
    }
  }
}
@media screen and (min-width: 1280px) {
  form{
    padding-top: 0 !important;
  }
}
</style>