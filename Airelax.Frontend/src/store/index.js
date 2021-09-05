import { createStore } from 'vuex'

export default createStore({
  state: {
    destination:"",
    adult:0,
    child:0,
    toddler:0,
    date: new Date(),
    isBodyShow: true,
    fullWidth: 0,
    nightCount: 0,
    room:{},
    roomPicture:[]
  },
  mutations: {
  },
  actions: {
  },
  getters: {
    TotalCustomer(state){
      return state.adult + state.child + state.toddler
    }
  }
})
