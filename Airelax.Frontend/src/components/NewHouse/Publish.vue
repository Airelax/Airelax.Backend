<template>
  <div class="contain">
    <div class="cover">
      <img v-if="houseSource.img" :src="houseSource.img" />
      <slot></slot>
    </div>
    <span>{{ houseSource.title }}</span>
    <div class="icon">
      <svg
        viewBox="0 0 32 32"
        xmlns="http://www.w3.org/2000/svg"
        role="presentation"
        focusable="false"
      >
        <g fill="none">
          <path
            d="m12 4 11.2928932 11.2928932c.3905243.3905243.3905243 1.0236893 0 1.4142136l-11.2928932 11.2928932"
          ></path>
        </g>
      </svg>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.contain {
  display: flex;
  color: #000;
  cursor: pointer;
  align-items: center;
  border: 2px solid #ddd;
  padding: 16px;
  border-radius: 12px;
  box-sizing: border-box;
  width: 100%;

  &:hover {
    border-color: #000;
  }

  span {
    display: block;
    text-align: left;
    padding: 0 10px;
    width: 80%;
    white-space: wrap;
    overflow: hidden;
    text-overflow: ellipsis;
  }

  .cover {
    width: 32px;
    height: 32px;

    img {
      width: 100%;
      height: 100%;
      display: block;
      object-fit: cover;
      border-radius: 8px;
    }
  }
  .icon {
    flex-grow: 1;
    display: flex;
    justify-content: flex-end;
    svg {
      display: block;
      fill: none;
      height: 16px;
      width: 16px;
      stroke: currentcolor;
      stroke-width: 4;
      overflow: visible;
    }
  }
}
</style>


<script>
export default {
  props: {
    houseSource: {
      type: Object,
      default: () => {
        return {
          img: "",
          title: "aaaaaaaaaaa aaaaaaaaaa aaaaaaaaa",
        };
      },
    },
  },
};
</script>