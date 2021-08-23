<template>
  <div class="contain">
    <div class="item">
      <h2>{{ title }}</h2>
      <div class="content">
        <textarea :maxlength="textLimit" rows="10" v-model="message"></textarea>
        <div>
          <span>{{ message.length }}</span
          >/<span>{{ textLimit }}</span>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.contain {
  display: flex;
  justify-content: center;
  width: 100%;
  height: 100%;
}

.item {
  margin: auto;
  width: 80%;
}

h2 {
  display: none;
}

.content {
  display: flex;
  flex-wrap: wrap;
  width: 100%;
}

textarea {
  resize: vertical;
  width: 100%;
  max-height: 25vh;
  border-color: #ccc;
}

@media screen and (min-width: 768px) {
  h2 {
    display: block;
    margin-bottom: 30px;
    font-size: 22px;
    font-weight: 900;
    text-align: left;
  }

  textarea {
    min-height: 25vh;
    max-height: 60vh;
  }
}
</style>

<script>
export default {
  data() {
    return {
      message: "",
    };
  },
  props: {
    title: {
      type: String,
    },
    textLimit: {
      type: Number,
      default: 50,
    },
  },
};
</script>