<template>
  <div class="row yourTrip">
    <h3>你的旅程</h3>
    <div class="col-9">
      <p>日期</p>
      <p>
        {{ $store.state.date.start }} -
        {{ $store.state.date.end}}
      </p>
    </div>
    <div class="col-3">
      <div
        class="btn"
        type="button"
        data-bs-toggle="offcanvas"
        data-bs-target="#during"
        aria-controls="during"
        v-if="fullWidth < 768"
      >
        編輯
      </div>
      <div
        class="btn"
        type="button"
        data-bs-toggle="modal"
        data-bs-target="#duringModal"
        v-if="fullWidth >= 768"
      >
        編輯
      </div>
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
    <div class="col-3">
      <div
        class="btn"
        type="button"
        data-bs-toggle="offcanvas"
        data-bs-target="#people"
        aria-controls="people"
        v-if="fullWidth < 768"
      >
        編輯
      </div>
      <div
        class="btn"
        type="button"
        data-bs-toggle="modal"
        data-bs-target="#peopleModal"
        v-if="fullWidth >= 768"
      >
        編輯
      </div>
    </div>
  </div>
  <!-- <768 -->
  <!-- Offcanvas -->
  <div
    class="offcanvas offcanvas-bottom duringOffcanvas"
    tabindex="-1"
    id="during"
    aria-labelledby="duringLabel"
    v-if="fullWidth < 768"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <h5 class="offcanvas-title" id="duringLabel" v-if="getDuring">
        {{ convertLocale($store.state.date.start) }} -
        {{ convertLocale($store.state.date.end) }}
      </h5>
    </div>
    <div class="offcanvas-body small">
      <SubDate></SubDate>
    </div>
    <div class="offcanvas-footer">
      <div
        class="btn"
        href="#"
        @click.prevent="$store.state.date = new Date()"
        @click="showDuring($store.state.date.start, $store.state.date.end)"
      >
        清除
      </div>
      <div
        class="btn btn-dark"
        data-bs-dismiss="offcanvas"
        @click="showDuring($store.state.date.start, $store.state.date.end)"
      >
        儲存
      </div>
    </div>
  </div>
  <div
    class="offcanvas offcanvas-bottom peopleOffcanvas"
    tabindex="-1"
    id="people"
    aria-labelledby="peopleLabel"
    v-if="fullWidth < 768"
  >
    <div class="offcanvas-header">
      <button
        type="button"
        class="btn-close text-reset"
        data-bs-dismiss="offcanvas"
        aria-label="Close"
      ></button>
      <h5 class="offcanvas-title" id="peopleLabel" v-if="getPeople">
        {{ $store.state.adult + $store.state.child }}位
        <span v-if="$store.state.toddler > 0">
          ,{{ $store.state.toddler }}名嬰幼兒
        </span>
      </h5>
    </div>
    <div class="offcanvas-body small">
      <SubPeople></SubPeople>
    </div>
    <div class="offcanvas-footer">
      <div
        class="btn btn-cancel"
        data-bs-dismiss="offcanvas"
        @click="judgeCount($store.state.adult)"
      >
        取消
      </div>
      <div
        class="btn btn-dark"
        data-bs-dismiss="offcanvas"
        @click="judgeCount($store.state.adult)"
      >
        儲存
      </div>
    </div>
  </div>
  <!-- >=768 -->
  <!-- Modal -->
  <div
    class="modal fade"
    id="duringModal"
    tabindex="-1"
    aria-labelledby="duringModalLabel"
    aria-hidden="true"
    v-if="fullWidth >= 768"
  >
    <div class="modal-dialog modal-lg modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <div
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></div>
        </div>
        <div class="modal-body">
          <div class="row input">
            <div
              class="col-2 me-auto"
              v-if="$store.state.date.end && $store.state.date.start"
            >
              {{
                ($store.state.date.end - $store.state.date.start) /
                1000 /
                24 /
                60 /
                60
              }}晚 {{}}
            </div>
          </div>
          <div class="date">
            <SubDate></SubDate>
          </div>
        </div>
        <div class="modal-footer">
          <div
            class="btn"
            href="#"
            @click.prevent="$store.state.date = new Date()"
            @click="showDuring($store.state.date.start, $store.state.date.end)"
          >
            清除
          </div>
          <div
            type="button"
            class="btn btn-dark"
            data-bs-dismiss="modal"
            @click="showDuring($store.state.date.start, $store.state.date.end)"
          >
            儲存
          </div>
        </div>
      </div>
    </div>
  </div>
  <div
    class="modal fade"
    id="peopleModal"
    tabindex="-1"
    aria-labelledby="peopleModalLabel"
    aria-hidden="true"
    v-if="fullWidth >= 768"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <div
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></div>
        </div>
        <div class="modal-body">
          <div class="people">
            <SubPeople></SubPeople>
          </div>
        </div>
        <div class="modal-footer">
          <div class="btn" href="#" data-bs-dismiss="modal">取消</div>
          <div
            type="button"
            class="btn btn-dark"
            data-bs-dismiss="modal"
            @click="judgeCount($store.state.adult)"
          >
            儲存
          </div>
        </div>
      </div>
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
  .col-3 {
    text-align: end;
    .btn {
      padding: 0;
      font-weight: 500;
      text-decoration: underline;
    }
  }
}
.duringOffcanvas {
  .offcanvas-header {
    padding: 20px 30px;
  }
  .offcanvas-body {
    padding-top: 30px;
    padding-bottom: 0;
  }
  .offcanvas-footer {
    display: flex;
    justify-content: space-between;
    padding: 20px 40px;
  }
}
.peopleOffcanvas {
  .offcanvas-header {
    padding: 20px 25px;
  }
  .offcanvas-body {
    padding: 0;
    .people {
      font-weight: 400;
    }
  }
  .offcanvas-footer {
    padding: 20px 40px 20px 30px;
    display: flex;
    justify-content: space-between;
    .btn-cancel {
      padding: 0;
      font-weight: 500;
      text-decoration: underline;
    }
  }
}
</style>

<script>
import SubDate from "../Subscribe/SubDate.vue";
import SubPeople from "../Subscribe/SubPeople.vue";
export default {
  data() {
    return {
      getDuring: false,
      getPeople: false,
    };
  },
  components: {
    SubDate,
    SubPeople,
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
    convertLocale(date) {
      return date.toLocaleDateString();
    },
  },
  props: {
    fullWidth: {
      type: Number,
    },
  },
};
</script>