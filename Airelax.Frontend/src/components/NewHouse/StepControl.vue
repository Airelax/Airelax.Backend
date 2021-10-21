<template>
  <div class="controls">
    <button class="back" @click="back">返回</button>
    <button
        :disabled="!isSelected"
        :class="{ active: isSelected }"
        @click="next"
        class="next"
    >
      下一步
    </button>
  </div>
</template>

<style lang="scss" scoped>
.controls {
  display: flex;
  justify-content: space-between;
  align-items: center;
  box-sizing: border-box;

  button {
    display: block;
    border: none;
    box-sizing: border-box;

    &.back {
      background-color: transparent;
      font-weight: 900;
      text-decoration: underline;
    }

    &.next {
      color: #fff;
      background-color: #ddd;
      padding: 14px 24px;
      cursor: not-allowed;
      border-radius: 8px;
    }

    &.active {
      background-color: black;
      cursor: pointer;
    }
  }
}
</style>


<script>
import axios from 'axios';

export default {
  data() {
    return {
      isSelected: this.$store.state.isNewHouseNextAvailable
    }
  },
  methods: {
    next: function () {
      const request = this.$store.state.newHouseRequest;
      let houseId = this.$route.params.id;
      const baseUrl = "/api/new-house"
      // const vm = this;
      axios({
        method: request.method,
        url: baseUrl + request.url,
        headers: {
          'Content-Type': 'application/json'
        },
        data: JSON.stringify(request.body)
      })
          .then(res => {
            if (!houseId) houseId = res.data;
            this.$router.push({
              name: request.redirectName,
              params: {id: houseId}
            });
          })
          .catch(err => console.log(err));
    },
    back(){
      this.$router.back();
    }
  },
  computed: {
    isAvailable() {
      return this.$store.state.isNewHouseNextAvailable;
    }
  },
  watch: {
    isAvailable(val) {
      this.isSelected = val;
    }
  }
};
</script>