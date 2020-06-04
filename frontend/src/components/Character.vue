<template>
  <div class="character">
    <img class="hp" src="/cards/characters/back-character.png" alt="hp" :style="`margin-right: ${livesShift}rem`" />
    <img class="img" :src="`/cards/characters/${player.character}.png`" :alt="player.character">
  </div>
</template>

<script>
export default {
  name: "Character",
  props: {
    player: { }
  },
  computed: {
    livesShift() {
      switch (this.player.hp)
      {
        case 1:
          return -8.5;
        case 2:
          return -6;
        case 3:
          return -3;
        case 4:
          return -0.7;
        default:
          return 1;
      }
    }
  }
}
</script>

<style lang="sass">
@import ../style

.character
  height: $cardHeight
  place-self: center
  img.img
    height: $cardHeight
    transform: rotate(0deg)
  img.hp
    height: $cardHeight
    transform: rotate(90deg)
</style>