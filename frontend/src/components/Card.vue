<template>
  <div class="card">
    <img v-if="reverseSide" src="/cards/play-cards/back-playing.png" alt="card-background" />
    <img v-else :src="`/cards/play-cards/${card.type}.png`" :alt="card.type" />
    {{ id }} - {{ reverseSide }}
  </div>
</template>

<script>
export default {
  name: "Card",
  props: {
    id: { },
    reverseSide: { default: false }
  },
  computed: {
    card() {
      return this.$store.state.cards[this.id];
    }
  }
  
}
</script>

<style lang="sass">

</style>