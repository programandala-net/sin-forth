\ lib/to-r.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-de.fs \ `pop-de`

: >r ( x -- ) ( R: -- x )
  pop-de  \ call pop_de ; x
  h pop,  \ pop hl ; return address
  d push, \ push de ; x
  jphl,   \ jp (hl) ; return

  \ doc{
  \
  \ >r ( x -- ) ( R: -- x ) "to-r"
  \
  \ Move _x_ from the data stack to the return stack.
  \
  \ See also: `r>`, `r@`, 2>r`, `dup>r`.
  \
  \ }doc
