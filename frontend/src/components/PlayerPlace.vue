<template>
  <div class="playerPlace" :class="placeClass">
    <div class="name">{{ player.name }}</div>
    <Role :player="player" />
    <Character :player="player" />
    <CardPlace :cards="player.cardInHand" class="inHand" :reverseSide="!isMe" />
    <CardPlace :cards="player.cardOnDesk" class="onDesk" />
  </div>
</template>

<script>
import CardPlace from "./CardPlace";
import Character from "./Character";
import Role from "./Role";

export default {
  name: "PlayerPlace",
  components: {
    CardPlace,
    Character,
    Role
  },
  props: {
    player: {},
    index: {}
  },
  computed: {
    isMe() {
      return this.$store.state.login.name == this.player.name;
    },
    placeClass() {
      const totalCount = Object.keys(this.$store.state.players).length;

      switch (this.index)
      {
        case 0:
          return "place-1 bottom";
        case 1:
          return totalCount < 5 ? "place-45 top" : "place-4 top";
        case 2:
          return totalCount < 6 ? "place-23 right" : "place-2 right";
        case 3:
          return totalCount < 7 ? "place-67 left" : "place-6 left";
        case 4:
          return "place-5 top";
        case 5:
          return "place-3 right";
        case 6:
          return "place-7 left";
        default:
          return "";
      }
    }
  }
};
</script>

<style lang="sass">
@import ../style

.playerPlace
  display: grid
  height: $playerPlaceHeight
  width: 100%
  grid-template-areas: "name name name" "role onDesk character" "role inHand character"
  grid-template-columns: min-content 1fr $characterWith
  &.top
    transform: rotate(180deg)
  &.right
    transform: rotate(270deg)
  &.left
    transform: rotate(90deg)

  .name
    grid-area: name
  .role
    grid-area: role
  .character
    grid-area: character
  .onDesk
    grid-area: onDesk
  .inHand
    grid-area: inHand
</style>