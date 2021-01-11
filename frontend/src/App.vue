<template>
  <div id="app">
    <PackOfCards :cards="packToTake" class="packToTake" reverseSide="true" @click="stir" />
    <PackOfCards :cards="packToLeave" class="packToLeave" />
    <CardPlace :cards="cardsOnDesk" class="cardsOnDesk" />
    <PlayerPlace v-for="(player, index) in players" :key="index" :player="player" :index="index" :class="getPosition(index)" />
  </div>
</template>

<script>
import { mapState } from "vuex";
import CardPlace from "./components/CardPlace";
import PackOfCards from "./components/PackOfCards";
import PlayerPlace from "./components/PlayerPlace";

export default {
  name: "App",
  components: {
    CardPlace,
    PackOfCards,
    PlayerPlace
  },
  computed: {
    ...mapState(["packToTake", "packToLeave", "cardsOnDesk", "players"])
  },
  methods: {
    stir() {
      if (this.packToTake.length > 0) return;

      this.$store.dispatch("stirCards");
    },
    getPosition(index) {
      if (index == 0) return "me";

      return `position_${(2 - this.$store.state.players.length) + ((index - 1) * 2)}`;
    }
  }
};
</script>

<style lang="sass">
@import ./constants

*
  margin: 0
  padding: 0

html, body
  width: 100%
  height: 100%

body
  min-width: 1540px
  min-height: 880px
  overflow: auto

#app
  width: 100%
  height: 100%
  display: grid
  grid-template-columns: repeat(21, 4.76%)
  grid-template-rows: repeat(21, 4.76%)
  place-items: center

  .packToTake
    grid-row: 10
    grid-column: 10
  .packToLeave 
    grid-row: 10
    grid-column: 12
  .cardsOnDesk
    grid-row: 14
    grid-column: 11
    width: $cardPlaceWidth

  .playerPlace
    &.me
      grid-row: 21
      grid-column: 11
      align-self: end
    &.position_-5
      grid-row: 13
      grid-column: 5
    &.position_-4
      grid-row: 6
      grid-column: 2
    &.position_-3
      grid-row: 8
      grid-column: 5
    &.position_-2
      grid-row: 4
      grid-column: 2
    &.position_-1
      grid-row: 3
      grid-column: 7
    &.position_0
      grid-row: 3
      grid-column: 11
    &.position_1
      grid-row: 3
      grid-column: 15
    &.position_2
      grid-row: 3
      grid-column: 8
    &.position_3
      grid-row: 8
      grid-column: 17
    &.position_4
      grid-row: 6
      grid-column: 9
    &.position_5
      grid-row: 13
      grid-column: 17
</style>