\ lib/allot.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230501T1150+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require d-p.fs        \ `dp`
require plus-store.fs \ `+!`

  \ doc{
  \
  \ allot ( n -- )
  \
  \ If _n_ is greater than zero, reserve _n_ bytes of data space.
  \ If _n_ is less than zero, release _n_ bytes of data space. If
  \ _n_ is zero, leave the data-space pointer unchanged.
  \ In other words: add _n_ to the data-space pointer `dp`.
  \
  \ See also: `here`.
  \
  \ }doc
