
<template>
  <div class="contain">
    <div class="create-helper">
      <Helper></Helper>
    </div>
    <div class="content">
      <slot><div class="error">Oops! Something Error</div></slot>
    </div>
    <div v-if="notFirst" class="step-controls">
      <StepControl></StepControl>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.create-helper {
  display: none;
}

.contain {
  width: 100%;
  position: relative;
  display: block;
  height: 100%;
}

.content {
  padding-bottom: 80px;
}

.step-controls {
  padding: 10px 15px;
  width: 100%;
  position: fixed;
  bottom: 0;
  border-top: 1px solid #000;
  background-color: #fff;
  box-sizing: border-box;
}

@media screen and (min-width: 768px) {
  .contain {
    display: flex;
    flex-direction: column;
    height: 100%;
  }

  .content {
    flex-grow: 1;
    padding-bottom: 0;
    height: 100%;
    overflow-y: auto;
    box-sizing: border-box;

    &::-webkit-scrollbar {
      display: none;
    }

    & {
      -ms-overflow-style: none;
      scrollbar-width: none;
    }
  }

  .create-helper {
    display: flex;
    padding: 20px 0;
  }

  .step-controls {
    position: static;
  }
}
</style>

<script>
import StepControl from "./StepControl.vue";
import Helper from "./Helper.vue";
export default {
  props: {
    notFirst: {
      type: Boolean,
      default: true,
    },
  },
  components: {
    StepControl,
    Helper,
  },
};
</script>