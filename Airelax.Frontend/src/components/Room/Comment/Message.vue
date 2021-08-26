<template>
  <div class="user">
    <img src="https://picsum.photos/56/56/?random=1" />
    <div class="item">
      <span>{{ msg.name }}</span>
      <span>{{ msg.date }}</span>
    </div>
  </div>
  <div class="massage">
    <p>{{ msg.content }}</p>
    <div class="allMsg">
      <span><u>顯示更多內容</u></span>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.user {
  display: flex;
  margin-bottom: 12px;
  align-items: center;
}
.user img {
  width: 45px;
  height: 45px;
  border-radius: 50%;
}
.item {
  padding-left: 12px;
  display: flex;
  flex-direction: column;
  text-align: start;
}
.item span:nth-child(1) {
  font-size: 16px;
  font-weight: 600;
  margin-bottom: .2rem;
}
.item span:nth-child(2) {
  color: #717171;
  font-size: 14px;
  margin-top: .2rem;
}
.massage {
  text-align: initial;
}
.massage p {
  text-align: justify;
  margin-bottom: 0;
  line-height: 1.5rem;
}
.allMsg {
  cursor: pointer;
  width: 124px;
  display: none;
}
.allMsg::after {
  content: "";
  display: inline-block;
  border: 8px solid transparent;
  border-left: 8px solid #222;
  border-radius: 50%;
  position: relative;
  top: 2px;
}
.allMsg span {
  font-weight: 600;
}
.allMsg span::after {
  content: "";
  display: inline-block;
  border: 6px solid transparent;
  border-left: 6px solid #fff;
  position: relative;
  z-index: 1;
  left: 11px;
}
@media screen and (min-width: 768px) {
  .user img {
    width: 56px;
    height: 56px;
  }
  .item {
    margin: auto 0;
  }
}
@media screen and (min-width: 1200px) {
  .user {
    margin-bottom: 16px;
  }
}
</style>

<script>
export default {
  props: ["msg"],
};
</script>