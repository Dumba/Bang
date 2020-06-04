<template>
  <div class="cardPlace">
    <Card v-for="card in cards" :key="card.id" :id="card" :reverseSide="reverseSide" />
  </div>
</template>

<script>
import Card from './Card';

export default {
  name: "CardPlace",
  components: {
    Card
  },
  props: {
    cards: { },
    reverseSide: { default: false }
  }
}
</script>

<style lang="sass">
@import ../style

.cardPlace
  height: $cardPlaceHeight
  margin: $gap
  display: flex
</style>