<template>
  <div class="playerPlace">
    <div class="name">{{ player.name }}</div>
    <Player :player="player" :isMe="isMe" />
    <CardPlace :cards="player.cardInHand" :inHand="true" :reverseSide="!isMe" />
    <CardPlace :cards="player.cardOnDesk" :inHand="false" />
  </div>
</template>

<script>
import CardPlace from "./CardPlace";
import Player from "./Player";

export default {
  name: "PlayerPlace",
  components: {
    CardPlace,
    Player
  },
  props: {
    player: { required: true },
    index: { required: true }
  },
  computed: {
    isMe() {
      return this.index == 0;
    }
  }
};
</script>

<style lang="sass">
@import ../constants

.playerPlace
  display: grid
  grid-template-columns: min-content $cardPlaceWidth $cardPlaceWidth
  grid-template-rows: min-content $cardHeight
  grid-gap: $cardPlaceGap
  &.me
    grid-template-columns: min-content $myCardPlaceWidth $myCardPlaceWidth
    grid-template-rows: min-content $myCardHeight
  
  .name
    grid-row: 1
    grid-column: 1 / 4
    font-size: 40px
    font-weight: bold
</style>