<template>
    <div class="mixHome">
        <div class="menu">
			<router-link to="/" class="logo"><img src="../../assets/image/Home/logo.png" alt="logo"></router-link >
				<div class="min_search_home d-none" @click="show">
					<button type="button" class="form-control " style="box-shadow:3px 3px 12px #cccccc;">開始搜尋
						<div class="iconSlt"><i class="fa fa-search"></i></div>
					</button>
				</div>
			<div class="d-flex align-items-center">
				<!-- Todo-根據有無登入顯示不同button -->
				<a href="/member/today" v-if="$store.state.login.token != ''"><button type="button" id="registerHome">切換至出租模式</button></a>
				<router-link to="/become-host/category" v-else><button type="button" id="registerHome">成為房東 / 體驗達人</button></router-link>
				<Member></Member>
			</div>
		</div>
		<keep-alive>
			<div class="search-div" v-if="isShow">
				<SearchBar></SearchBar>
			</div>
		</keep-alive>
    </div>
</template>

<script>
import Member from  '../Home/Member';
import SearchBar from '../Home/SearchBar';
export default {
	data(){
		return{
			isShow: false,
		}
	},
    components:{
		Member, SearchBar
	},
	methods:{
		show(){
			let vm = this
			vm.isShow = true;
			let minSearch = document.querySelector('.min_search_home');
			minSearch.classList.add('d-none');
			window.addEventListener('scroll',()=>{
				vm.isShow = false;
				minSearch.classList.remove('d-none');
			})
		},
		change(){
            let mix = document.querySelector('.mixHome');
            let minSearch = document.querySelector('.min_search_home');
            let register = document.getElementById('registerHome');
            if (top!==null && mix !== null && minSearch !== null){
                window.addEventListener("scroll", function() {
                    let top = document.documentElement.scrollTop; 
                    if(top>100){
                        mix.classList.add('homeStyle');
                        minSearch.classList.remove('d-none');
                        register.classList.add('toggle');
                    }
                    else{
                        mix.classList.remove('homeStyle');
                        minSearch.classList.add('d-none');
                        register.classList.remove('toggle');
                    }
                });
            }
        }
	},
	mounted(){
        const vm = this;
        window.addEventListener("scroll",function(){
            vm.change();
            let cHeight = document.documentElement.clientHeight;
            let sHeight = document.documentElement.scrollHeight;
            let sTop = document.documentElement.scrollTop;
            if(sHeight <= cHeight+ sTop +200)
                vm.isRwdShow = false;
            else
                vm.isRwdShow = true;
            })
    },
    computed:{
      getWidth(){
        return this.$store.state.fullWidth;
      }
    },
    watch:{
      getWidth(){
        this.change();
      }
    }
}
</script>

<style lang="scss" scoped>
.mixHome{
	width: 100%;
	height: fit-content;
	position: absolute;
	padding: .5rem 0;
	top: 0;
	left: 0;
	z-index: 20;
	background-color: transparent;
	box-shadow: unset;
	&.homeStyle{
		transition: .3s;
		position: fixed;
		background-color: #fff;
		box-shadow: 3px 3px 5px rgb(160, 159, 159);
	}
	.search-div{
		width: 100%;
		transition: .3s;
		height: 5rem;
	}
	.menu {
		width: 100%;
		display: flex;
		justify-content: space-around;
		background-color: transparent;
		img{
			width: 10rem;
		}
		.logo {
			margin-right: 60vw;
		}
		span {
			margin-right: 12vw;
		}
		li {
			display: inline-block;
		}
		.nav {
			a {
				font-size: 16px;
				color: #ffffff;
				line-height: 40px;
				text-align: center;
				text-decoration: none;
				padding: 00px 16px;
			}
		}
		#registerHome {
			font-size: 14px;
			font-weight: bold;
			margin-right: 1rem;
			background-color: transparent;
			border: none;
			padding: 1rem 1rem;
			border-radius: 30px;
			color: #fff;
			&.toggle {
				color: rgb(0, 0, 0);
			}
			&:hover {
				background-color: rgba(126, 125, 125, 0.2) !important;
			}
		}
		.login {
			#login {
				display: flex;
				justify-content: end;
				align-items: center;
				padding: 5px 8px;
				border-radius: 20px;
				border: none;
			}
			label {
				font-size: 17px;
				padding-left: 5px;
				display: flex;
				justify-content: center;
				align-items: center;
			}
			i {
				font-size: 28px;
				color: #484848d5;
				padding-left: 12px;
			}
		}
		.min_search_home {
			display: flex;
			justify-content: center;
			align-items: center;
			position: absolute;
			top: 20%;
			transition: .3s;
			button {
				width: 300px;
				height: 50px;
				display: flex;
				justify-content: left;
				align-items: center;
				background: #ffffff;
				border: none;
				font-weight: bold;
				float: left;
				color: #222222;
				text-align: left;
				padding-left: 35px;
				border-radius: 50px;
				&:hover,
				&:focus,
				&:active {
					outline: none;
				}
				.iconSlt {
					position: relative;
					left: 150px;
					height: 40px;
					width: 40px;
					line-height: 40px;
					border-radius: 50px;
					background: #ff385c;
					color: #ffff;
					text-align: center;
				}
			}
		}
	}
}
</style>