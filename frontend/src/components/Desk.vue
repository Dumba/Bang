<template>
  <div class="desk">
    <PackOfCards :cards="packOfCardsTake" reverseSide="true" class="packToTake" />
    <PackOfCards :cards="packOfCardsLeave" class="packToLeave" />
    <PlayerPlace v-for="(player, name, index) in players" :key="name" :player="player" :index="index" />
    <CardPlace :cards="cardsOnDesk" class="cardsOnDesk" />
  </div>
</template>

<script>
import { mapState } from "vuex";
import CardPlace from "./CardPlace";
import PackOfCards from "./PackOfCards";
import PlayerPlace from "./PlayerPlace";

export default {
  name: "Desk",
  components: {
    CardPlace,
    PackOfCards,
    PlayerPlace
  },
  computed: {
    ...mapState(["packOfCardsTake", "packOfCardsLeave", "cardsOnDesk", "players"]),
    playersCount() {
      return Object.Keys(this.players).length;
    }
  }
};
</script>

<style lang="sass">
@import ../style

.desk
  display: grid
  grid-template-columns: $playerPlaceHeight 1fr 1fr $playerPlaceHeight
  grid-template-rows: $playerPlaceHeight 1fr 1fr $playerPlaceHeight

  .packToTake
    grid-column: 2
    grid-row: 2
    justify-self: end
  .packToLeave
    grid-column: 3
    grid-row: 2
    justify-self: start
  .cardsOnDesk
    grid-column: 2 / 4
    grid-row: 3
    justify-self: center

  .place-1
    grid-column: 2 / 4
    grid-row: 4
  .place-2
    grid-column: 4
    grid-row: 3 / 5
  .place-3
    grid-column: 4
    grid-row: 1 / 3
  .place-4
    grid-column: 3
    grid-row: 1
  .place-5
    grid-column: 2
    grid-row: 1
  .place-6
    grid-column: 1
    grid-row: 1 / 3
  .place-7
    grid-column: 1
    grid-row: 3 / 5
  .place-23
    grid-column: 4
    grid-row: 1 / 5
  .place-45
    grid-column: 2 / 4
    grid-row: 1
  .place-67
    grid-column: 1
    grid-row: 1 / 5
</style>