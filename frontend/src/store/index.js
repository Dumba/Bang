import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    players: [
      {
        name: "0pepa",
        role: "outlaw",
        character: "willy-the-kid",
        hp: 1,
        cardInHand: [
          1, 2, 4, 5, 6, 7
        ],
        cardOnDesk: [
          3, 2, 4, 5, 6, 7
        ]
      },
      {
        name: "1karel",
        role: "sheriff",
        character: "suzy-lafayette",
        hp: 3,
        cardInHand: [ 
          3, 2, 4, 5, 6, 7 ],
        cardOnDesk: [ 
          3, 2, 4, 5, 6, 7 ]
      },
      {
        name: "2josef",
        role: "outlaw",
        character: "pedro-ramirez",
        hp: 2,
        cardInHand: [
          3, 2, 4, 5, 6, 7],
        cardOnDesk: [ 
          3, 2, 4, 5, 6, 7 ]
      },
      {
        name: "3jana",
        role: "vice",
        character: "vulture-sam",
        hp: 1,
        cardInHand: [
          3, 2, 4, 5, 6, 7],
        cardOnDesk: [ 
          3, 2, 4, 5, 6, 7 ]
      },
      {
        name: "4jana",
        role: "vice",
        character: "vulture-sam",
        hp: 1,
        cardInHand: [
          3, 2, 4, 5, 6, 7],
        cardOnDesk: [ 
          3, 2, 4, 5, 6, 7 ]
      },
      {
        name: "5jana",
        role: "vice",
        character: "vulture-sam",
        hp: 1,
        cardInHand: [
          3, 2, 4, 5, 6, 7],
        cardOnDesk: [ 
          3, 2, 4, 5, 6, 7 ]
      },
      {
        name: "6jana",
        role: "vice",
        character: "vulture-sam",
        hp: 1,
        cardInHand: [
          3, 2, 4, 5, 6, 7],
        cardOnDesk: [ 
          3, 2, 4, 5, 6, 7 ]
      }
    ],
    cardsOnDesk: [ 3, 2, 4, 5, 6, 7 ],
    packToTake: [ 6, 6, 6 ],
    packToLeave: [ 6, 6, 6 ],

    // static
    cards: {
      1: {
        name: "appaloosa",
        color: "4S"
      },
      2: {
        name: "bang",
        color: "5S"
      },
      3: {
        name: "barrel",
        color: "4K"
      },
      4: {
        name: "beer",
        color: "4K"
      },
      5: {
        name: "carabine",
        color: "4K"
      },
      6: {
        name: "catbalou",
        color: "4K"
      },
      7: {
        name: "diligenza",
        color: "4K"
      }
    }
  },
  mutations: {
    moveCards: (state, payload) => { // source { type, player, place }, target, card
      var source = state[payload.source.type];
      if (payload.source.player != null && payload.source.place != null)
        source = source[payload.source.player][payload.source.place];

      var target = state[payload.target.type];
      if (payload.target.player != null && payload.target.place != null)
        target = target[payload.target.player][payload.target.place];

      var card = source.pop(payload.card);
      target.push(card);
    },
    changeLives: (state, payload) => { // count
      state.players[0].hp += payload.count;
    },
    stirCards: (state, payload) => { // cards
      state.packToTake = payload.cards;
      state.packToLeave = [];
    }
  },
  actions: {
    moveCards: (context, payload) => {
      // TODO: send
      context.commit('moveCands', payload);
    },
    changeLives: (context, payload) => {
      // TODO: send
      context.commit('changeLives', payload);
    },
    stirCards: (context, payload) => {
      // TODO: send
      context.commit('stirCards', payload);
    }
  },
  modules: {
  }
})
