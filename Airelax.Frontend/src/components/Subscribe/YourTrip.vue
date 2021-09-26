<template>
  <div class="row yourTrip">
    <h3>你的旅程</h3>
    <div class="col-9">
      <p>日期</p>
      <p>
        {{ $store.state.date.start }} -
        {{ $store.state.date.end }}
      </p>
    </div>

    <div class="col-9">
      <p>房客人數</p>
      <p>
        {{ $store.state.adult + $store.state.child }}位
        <span v-if="$store.state.toddler > 0">
          ,{{ $store.state.toddler }}名嬰幼兒
        </span>
      </p>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.yourTrip {
  .col-9 {
    p {
      font-size: 16px;
      padding: 10px 0;
    }
    p:nth-of-type(1) {
      font-weight: 500;
    }
    p:nth-of-type(2) {
      color: #717171;
    }
  }
}
</style>

<script>
export default {
  data() {
    return {
      getDuring: false,
      getPeople: false,
    };
  },
  methods: {
    judgeCount(adult) {
      if (adult > 0) this.getPeople = true;
      else this.getPeople = false;
    },
    showDuring(start, end) {
      if (start && end) this.getDuring = true;
      else this.getDuring = false;
    },
  },
  props: {
    fullWidth: {
      type: Number,
    },
  },
};
</script>