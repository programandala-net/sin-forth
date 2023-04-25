\ lib/greater-than.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T1600+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require swap.fs      \ `swap`
require less-than.fs \ `<`

: > ( n1 n2 -- f )
  swap < ;

  \ doc{
  \
  \ > ( n1 n2 -- f ) "greater-than"
  \
  \ _f_ is true if and only if _n1_ is greater than _n2_.
  \
  \ See also: `<`, `u>`, `0>`, `max`.
  \
  \ }doc
