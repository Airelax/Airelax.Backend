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
        isNewHouseOptionSelected: false,
        isNewHouseNextAvailable: false,
        newHouseRequest: {},
    },
    mutations: {
        setNewHouseNextAvailable(state, isAvailable) {
            state.isNewHouseNextAvailable = isAvailable;
        },
        setNewHouseRequest(state, request) {
            state.newHouseRequest = request;
        }
    },
    actions: {},
    getters: {}
})
