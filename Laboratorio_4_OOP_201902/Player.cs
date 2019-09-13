using Laboratorio_4_OOP_201902.Cards;
using Laboratorio_4_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Player
    {
        //Constantes
        private const int LIFE_POINTS = 2;
        private const int START_ATTACK_POINTS = 0;

        //Static
        private static int idCounter;

        //Atributos
        private int id;
        private int lifePoints;
        private int attackPoints;
        private Deck deck;
        private Hand hand;
        private Board board;
        private SpecialCard captain;

        //Constructor
        public Player()
        {
            LifePoints = LIFE_POINTS;
            AttackPoints = START_ATTACK_POINTS;
            Deck = new Deck();
            Hand = new Hand();
            Id = idCounter++;
        }

        //Propiedades
        public int Id { get => id; set => id = value; }
        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = value;
            }
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return this.hand;
            }
            set
            {
                this.hand = value;
            }
        }
        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }
        public SpecialCard Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                this.captain = value;
            }
        }

        //Metodos
        public void DrawCard(int cardId = 0)
        {
            Deck deck = new Deck();
            EnumType tipo = deck.Cards[cardId].Type;
            if (Convert.ToString(tipo) == "CombatCard")
            {
                CombatCard combatCard = (CombatCard) deck.Cards[cardId];
                hand.AddCard(combatCard);
                deck.DestroyCard(cardId);
            }
            else
            {
                SpecialCard specialCard =(SpecialCard) deck.Cards[cardId];
                hand.AddCard(specialCard);
                deck.DestroyCard(cardId);
            }
            /*
            1- Definir si la carta a robada del mazo es CombatCard o SpecialCard
            2- Luego deberá agregar la carta robada al mazo. En este paso debe respetar el tipo por referencia, para esto:
                2.1- Asigne una variable a la carta robada del mazo, ejemplo, CombatCard card = deck.Cards[cardId]
                2.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta del mazo.
                2.3- Agregue la nueva carta a la mano
            Elimine la carta del mazo.
            Hint: Utilice los métodos ya creados en Hand y Deck (AddCard y DestroyCard), no se preocupe de la implementacion de estos aun.*/
            throw new NotImplementedException();
        }
        public void PlayCard(int cardId, EnumType buffRow = EnumType.None)
        {
            EnumType tipo1 = deck.Cards[cardId].Type;
            if (Convert.ToString(tipo1) == "CombatCard")
            {
                CombatCard cards = (CombatCard) deck.Cards[cardId];
                board.AddCard(cards, id);
                hand.DestroyCard(cardId);

            }

            else
            {
                SpecialCard specialCard = (SpecialCard)deck.Cards[cardId];
                string tipo = Convert.ToString(specialCard.Type);
                if (tipo == "buff")
                {
                    board.AddCard(specialCard, id, buffRow);
                }
                else if (tipo == "weather")
                {
                    board.AddCard(specialCard);
                }
                hand.DestroyCard(cardId);
            }
            /*Realice el mismo procedimiento que en DrawCard, solo que ahora es desde Hand a Board.
              En caso de CombatCard siga el mismo procedimiento, recuerde que el método AddCard de Board requiere el id del usuario.
              En caso de SpecialCard:
                1- Realice los pasos 2.1 y 2.2 de DrawCard
                2- Identifique el tipo de la carta, 
                    2.1- Si es buff:
                        -El metodo AddCard de Board requiere el Id del usuario
                        -El metodo requiere la entrada buff{fila a la que se va a jugar}. Ejemplo buffmelee, este dato viene en el parámetro buffRow.
                    2.2- Si es weather:
                        -El metodo AddCard solo requiere la carta.
                3- Elimine la carta de la mano. 
             */
        }
        public void ChangeCard(int cardId)
        {

            string tipoCard =Convert.ToString(hand.Cards[cardId].Type);
            Card card1 = hand.Cards[cardId];
            if (tipoCard == "combatCard")
            {
                CombatCard combatCard = (CombatCard)hand.Cards[cardId];
                card1 = combatCard;
            }
            else
            {
                SpecialCard specialCard = (SpecialCard)hand.Cards[cardId];
                card1 = specialCard;
            }
            hand.DestroyCard(cardId);
            Random random = new Random();
            int var = random.Next(0, deck.Cards.Count);
            Card card = deck.Cards[var];
            DrawCard(var);
            deck.AddCard(card1);

            /* Debe cambiar la carta en la posicion cardId de la mano por una carta aleatoria del mazo.
                1- Defina si la carta a cambiar de la mano es CombatCard o SpecialCard. Luego (Esto permite cambiar la referencia):
                        1.1- Asigne una variable a la carta a cambiar de la mano, ejemplo, CombatCard card = hand.Cards[cardId]
                        1.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta de la mano a cambiar.
                2- Elimine la carta de la mano
                3- Implemente Random
                4- Cree una variable que obtenga un numero aleatorio dentro del total de cartas del mazo.
                5- Obtenga la carta aleatoria del mazo (puede utilizar el método DrawCard) y cree una nueva carta con sus valores. Agreguela a la mano. 
                6- Elimine la carta aleatoria escogida del mazo.
                7- Agregue la carta original de la mano al mazo.
            */
        }

        public void FirstHand()
        {
            List<Card> desorden = deck.Shuffle();
            for(int i = 0; i<10;i++)
            {
                hand.AddCard(desorden[i]);
            }

            
            /*Debe obtener 10 cartas aleatorias del mazo y asignarlas a la mano.
            Utilice el metodo DrawCard con 10 numeros de id aleatorios.
            */
        }

        public void ChooseCaptainCard(SpecialCard captainCard)
        {
            Captain = captainCard;
        }

    }
}
