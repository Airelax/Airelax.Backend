<template>
  <div class="record px-4 ">
    <div class="row ">
      <div class="col p-0">
        <h3>近期瀏覽紀錄</h3>
        <p>已根據目前的搜尋條件更新日期與價格。</p>
      </div>
      <div class="col d-none d-md-blocks navigation p-0"></div>
    </div>
    <div class="row me-0">
      <div class="scroll">
        <RecordRoom :rooms="rooms" :nightCount="nightCount"></RecordRoom>
      </div>
    </div>
  </div>
</template>
<style lang="scss" scoped>
* {
  font-family: "Noto Sans TC", sans-serif;
  .record {
    padding-top: 30px;
    .row:nth-of-type(1) {
      .col:nth-of-type(1) {
        padding-top: 0;
        padding-bottom: 0;
        h3,
        p {
          padding: 0 8px;
          text-align: start;
          color: #717171;
        }
        h3 {
          color: #000;
          font-weight: 700;
          font-size: 1.5rem;
          margin-bottom: 1rem;
        }
      }
    }
    .row:nth-of-type(2) {
      height: 400px;
      overflow: hidden;
      .scroll {
        display: flex;
        flex-wrap: nowrap;
        overflow-x: scroll;
        height: 600px;
      }
    }
  }
}
</style>
<script>
import RecordRoom from "./RecordRoom";
export default {
  components: {
    RecordRoom,
  },
  props: {
    rooms: { type: Object },
    nightCount: { type: Number },
  },
  data() {
    return {
      pricedetail: null,
    };
  },
};
</script>