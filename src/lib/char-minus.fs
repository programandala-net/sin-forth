\ lib/char-minus.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1334+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require one-minus.fs \ `1-`

synonym char- 1+

  \ doc{
  \
  \ char- ( n1 -- n2 ) "char-minus"
  \
  \ Subtract the size in bytes of a character to _n1_,
  \ giving _n2_.
  \
  \ NOTE: ``char-`` is implemented as a synonym of `1-`.
  \
  \ See also: `char+`, `chars`.
  \
  \ }doc
