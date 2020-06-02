<template>
  <div class="desk">
    <PackOfCards :cards="packOfCardsTake" reverseSide="true" class="packToTake" />
    <PackOfCards :cards="packOfCardsLeave" class="packToLeave" />
    <PlayerPlace v-for="(player, name, index) in players" :key="name" :player="player" :class="`place-${index}`" />
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
    ...mapState(["packOfCardsTake", "packOfCardsLeave", "cardsOnDesk", "players"])
  }
};
</script>

<style lang="sass">

</style>