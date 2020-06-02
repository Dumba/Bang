<template>
  <div class="packOfCards">
    <Card v-if="cards.length > 0" :id="cards[0]" :reverseSide="reverseSide" />
  </div>
</template>

<script>
import Card from "./Card";

export default {
  name: "PackOfCards",
  components: {
    Card
  },
  props: {
    cards: {},
    reverseSide: { default: false }
  }
}
</script>

<style lang="sass">

</style>