import {createStore} from 'vuex'

export default createStore({
    state: {
        destination: "",
        adult: 0,
        child: 0,
        toddler: 0,
        date: new Date(),
        isBodyShow: true,
        fullWidth: 0,
        nightCount: 0,
        room: {},
        roomPicture: [],
        isNewHouseOptionSelected: false,
        isNewHouseNextAvailable: false,
        newHouseRequest: {},
        message: {},
        signalCommunications: [],
        wishListData: {},
        selectedWishHouseId: '',
        connection: null,
        unreadCount: 0,
        filters: {
            freeCancel: false,
            lowPrice: "",
            highPrice: "",
            realtime: false,
            roomCategories: "",
            facilities: "",
            houseTypes: "",
            features: "",
            allowPet: false,
            allowSmoke: false
        },
        login: {
            token: "",
            memberId: ""
        }
    },
    mutations: {
        setNewHouseNextAvailable(state, isAvailable) {
            state.isNewHouseNextAvailable = isAvailable;
        },
        setNewHouseRequest(state, request) {
            state.newHouseRequest = request;
        },
    },
    actions: {},
    getters: {
        TotalCustomer(state) {
            return state.adult + state.child + state.toddler
        },
        TotalPrice(state) {
            return state.message.paymentDetail.serviceFee + state.message.paymentDetail.cleanFee + state.message.paymentDetail.taxFee
        }
    }
})
