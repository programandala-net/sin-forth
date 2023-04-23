\ lib/char-minus.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require one-minus.fs \ `1-`

get-order get-current

target-definitions

synonym char- 1+

  \ doc{
  \
  \ char- ( n1 -- n2 ) "char-minus"
  \
  \ Subtract the size in bytes of a character to _n1_,
  \ giving _n2_.
  \
  \ ``char-`` is an `alias` of `1-`.
  \
  \ See also: `char+`, `chars`.
  \
  \ }doc

set-current set-order
