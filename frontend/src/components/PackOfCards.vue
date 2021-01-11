<template>
  <div class="packOfCards">
    <Card :name="firstCardName" :reverseSide="reverseSide" />
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
  },
  computed: {
    firstCardName() {
      if (this.cards.length > 0)
        return this.$store.state.cards[this.cards[0]].name;

      return "_back";
    }
  }
}
</script>

<style lang="sass">

</style>
