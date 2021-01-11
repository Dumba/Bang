<template>
  <div class="card" :class="{ rotated: rotate, hoverDetail: hoverDetail }">
    <img v-if="reverseSide" :src="`/cards/${type}/_back.png`" alt="card-background" />
    <img v-else :src="`/cards/${type}/${name}.png`" :alt="name" />
  </div>
</template>

<script>
export default {
  name: "Card",
  props: {
    name: { },
    type: { default: "play-cards" },
    color: { default: null },
    reverseSide: { default: false },
    rotate: { default: false}
  },
  computed: {
    hoverDetail() {
      return this.type == "play-cards";
    }
  }
}
</script>

<style lang="sass">
@import ../constants

.me .card
  height: $myCardHeight
  width: $myCardWidth
  &.rotated
    width: $myCardHeight

.card
  height: $cardHeight
  width: $cardWidth

  &.rotated
    width: $cardHeight
    transform: rotate(90deg)
  // &.hoverDetail:hover
  //   height: $myCardHeight
  //   width: $myCardWidth
  //   z-index: 5

  img
    height: 100%
</style>