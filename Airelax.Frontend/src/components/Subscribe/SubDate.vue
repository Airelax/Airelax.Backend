<template>
  <v-date-picker
    id="datepicker"
    v-model="$store.state.date"
    color="pink"
    is-range
    :model-config="modelConfig"
    :columns="$screens({ default: 1, md: 2 })"
    :rows="$screens({ default: 1 })"
    :min-date="new Date()"
  />
</template>
<style lang="scss" scoped>
.date {
  padding-bottom: 1.5rem;
  margin-top: 1.5rem;
  .txt {
    h2 {
      text-align: left;
      font-size: 1.5rem;
      font-weight: 900;
    }
    p {
      text-align: left;
      font-size: 0.9rem;
      color: #717171;
      margin: 1rem 0;
    }
  }
  a {
    text-align: left;
    display: block;
    color: #222222;
    font-size: 1rem;
    margin-left: 1.5rem;
    font-weight: 700;
  }
}
@media screen and (min-width: 768px) {
  .date {
    border: none;
    .clear {
      display: flex;
      justify-content: flex-end;
    }
  }
}
</style>
<script>
export default {
    data() {
        return {
            modelConfig: {
                type: 'string',
                mask: 'YYYY年MM月DD日'
            },
        }
    }
}
</script>