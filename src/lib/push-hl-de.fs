\ lib/push-hl-de.fs
\ by Marcos Cruz (programandala.net), 2015, 2016, 2020.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ push-hl-de {{{1

: push-hl-de ( -- x1 x2 | d )
                      \             ; T Cycles
  ix decp,            \ dec ix      ;  10
  h 0 ix stx,         \ ld (ix+0),h ;  19
  ix decp,            \ dec ix      ;  10
  l 0 ix stx,         \ ld (ix+0),l ;  19
  ix decp,            \ dec ix      ;  10
  d 0 ix stx,         \ ld (ix+0),d ;  19
  ix decp,            \ inc ix      ;  10
  e 0 ix stx,         \ ld (ix+0),e ;  19
  ;                   \ ret         ;  10
                      \             ; 126 total (126 average with pop-hl-de)

  \ doc{
  \
  \ push-hl-de  ( -- x1 x2 | d )
  \
  \ First push the content of the ``HL`` Z80 register _x1_. Then push
  \ the content of the ``DE`` Z80 register _x2_. The cell pair _x1 x2_
  \ can be seen also a double number _d_, equivalent to the content of
  \ the theoretic register pair ``DEHL``, being ``DE`` its high part
  \ (on top of stack) and ``HL`` its low part.
  \
  \ See also: `pop-de-hl`, `push-de-hl`, `push-bc`, `push-de`,
  \ `push-hl`, `push-a`.
  \
  \ }doc
