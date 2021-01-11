<template>
  <div class="cardPlace" :class="{ inHand: inHand, onDesk: !inHand }">
    <div v-for="cardId in cards" :key="cardId" class="cardHolder">
      <Card :name="getCard(cardId).name" :reverseSide="reverseSide" />
    </div>
  </div>
</template>

<script>
import Card from "./Card";

export default {
  name: "CardPlace",
  components: {
    Card
  },
  props: {
    cards: {},
    inHand: { default: false },
    reverseSide: { default: false }
  },
  methods: {
    getCard(id) {
      return this.$store.state.cards[id];
    }
  }
};
</script>

<style lang="sass">
@import ../constants

.cardPlace
  display: grid
  height: $cardHeight
  justify-items: start
  grid-auto-flow: column
  grid-auto-columns: 1fr

  .cardHolder
    width: 1px
    &:last-child
      width: $cardWidth
    &:hover
      width: $myCardWidth
    
    .card:hover
      height: $myCardHeight
      width: $myCardWidth

.me .cardPlace .cardHolder:last-child
  width: $myCardWidth
</style>