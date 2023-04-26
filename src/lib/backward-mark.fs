\ lib/backward-mark.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1306+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

get-order get-current

compiler-definitions

compiler{

synonym <mark t-here

}

  \ doc{
  \
  \ <mark  Compiler: ( -- dest ) "backward-mark"
  \
  \ _dest_ is the current target memory pointer, which is hold by
  \ `memory>` to be used as the destination of a backward branch.
  \ _dest_ is typically only used by `<resolve` to compile a branch
  \ address.
  \
  \ See also: `>mark`, `begin`, `t-here`.
  \
  \ }doc

set-current set-order
