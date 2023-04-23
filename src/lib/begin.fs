\ lib/begin.fs
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

require backward-mark.fs \ `<mark`

get-order get-current

compiler-definitions

compiler{

synonym begin <mark

}

  \ doc{
  \
  \ begin  Compilation: ( -- dest )
  \
  \ Mark the start of a sequence for repetitive execution, leaving
  \ _dest_ to be resolved by the corresponding `until`, `again` or
  \ `repeat`.
  \
  \ ``begin`` is a synonym of `<mark`.
  \
  \ See also: `while`, `do`.
  \
  \ }doc

set-current set-order
